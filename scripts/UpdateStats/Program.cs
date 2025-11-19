using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace UpdateStats
{
    internal static class Program
    {
        private static readonly HttpClient Client = new();
        private const string Username = "Durez";

        private static async Task Main()
        {
            Console.WriteLine("🔄 Получение статистики с LeetCode...");
            
            var stats = await GetLeetCodeStats();

            if (stats != null)
            {
                await SaveStats(stats);
                await UpdateReadme(stats);

                Console.WriteLine("✅ Статистика обновлена!");
                Console.WriteLine($"📊 Решено задач: {stats.TotalSolved}");
                Console.WriteLine($"🟢 Легкие: {stats.EasySolved}");
                Console.WriteLine($"🟡 Средние: {stats.MediumSolved}");
                Console.WriteLine($"🔴 Сложные: {stats.HardSolved}");
            }
        }

        private static async Task<LeetCodeStats?> GetLeetCodeStats()
        {
            const string query = """

                                             {
                                                 matchedUser(username: "
                                 """ + Username + """
                                                  ") {
                                                                      username
                                                                      submitStats {
                                                                          acSubmissionNum {
                                                                              difficulty
                                                                              count
                                                                              submissions
                                                                          }
                                                                          totalSubmissionNum {
                                                                              difficulty
                                                                              count
                                                                              submissions
                                                                          }
                                                                      }
                                                                      profile {
                                                                          ranking
                                                                      }
                                                                  }
                                                                  recentSubmissionList(username: "
                                                  """ + Username + """
                                                                   ", limit: 10) {
                                                                                       title
                                                                                       titleSlug
                                                                                       timestamp
                                                                                       statusDisplay
                                                                                       lang
                                                                                   }
                                                                               }
                                                                   """;
            
            var payload = new { query };
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            
            Client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
            
            try
            {
                var response = await Client.PostAsync("https://leetcode.com/graphql", content);
                response.EnsureSuccessStatusCode();
                
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(responseContent);

                if (data["errors"] == null) 
                    return ParseStats(data);
                
                Console.WriteLine("Error in response: " + data["errors"]);
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return null;
            }
        }

        private static LeetCodeStats? ParseStats(JObject data)
        {
            var matchedUser = data["data"]?["matchedUser"];
            if (matchedUser == null) 
                return null;
            
            var submissions = matchedUser["submitStats"]?["acSubmissionNum"];
            var totalSubmissions = matchedUser["submitStats"]?["totalSubmissionNum"];
            
            var stats = new LeetCodeStats
            {
                UpdatedAt = DateTime.Now
            };

            if (submissions != null)
                foreach (var submission in submissions)
                {
                    var difficulty = submission["difficulty"]?.ToString().ToLower();
                    var count = submission["count"]?.Value<int>() ?? 0;

                    switch (difficulty)
                    {
                        case "all": stats.TotalSolved = count; break;
                        case "easy": stats.EasySolved = count; break;
                        case "medium": stats.MediumSolved = count; break;
                        case "hard": stats.HardSolved = count; break;
                    }
                }

            var totalAccepted = stats.TotalSolved;
            var totalAttempts = 0;

            if (totalSubmissions != null)
                foreach (var submission in totalSubmissions)
                    totalAttempts += submission["count"]?.Value<int>() ?? 0;

            stats.AcceptanceRate = totalAttempts > 0 ? 
                $"{(double)totalAccepted / totalAttempts * 100:F1}%" : "0%";
                
            stats.Ranking = matchedUser["profile"]?["ranking"]?.ToString() ?? "N/A";
            
            var recentSubs = data["data"]?["recentSubmissionList"];
            if (recentSubs == null) 
                return stats;
            
            foreach (var sub in recentSubs)
            {
                if (sub["statusDisplay"]?.ToString() != "Accepted")
                    continue;
                
                var titleSlug = sub["titleSlug"]?.ToString();
                if (titleSlug != null)
                {
                    var metadata = GetSolutionMetadata(titleSlug);
                        
                    stats.RecentSolutions.Add(new RecentSolution
                    {
                        Title = sub["title"]?.ToString() ?? string.Empty,
                        TitleSlug = titleSlug,
                        GithubPath = metadata.GithubPath,
                        Tags = metadata.Tags,
                        TimeComplexity = metadata.TimeComplexity,
                        MemoryComplexity = metadata.MemoryComplexity
                    });
                }

                if (stats.RecentSolutions.Count >= 5) break;
            }

            return stats;
        }

        private static SolutionMetadata GetSolutionMetadata(string titleSlug)
        {
            if (string.IsNullOrEmpty(titleSlug))
                return new SolutionMetadata();
            
            var metadata = new SolutionMetadata();
            var directories = new[] { "src/Easy", "src/Medium", "src/Hard" };
            
            foreach (var dir in directories)
            {
                if (!Directory.Exists(dir))
                    continue;
                    
                var solutionDir = FindSolutionDirectory(dir, titleSlug);
                
                metadata.GithubPath = $"[📁](./{solutionDir})";

                if (solutionDir != null)
                {
                    var metadataFromFiles = ExtractMetadataFromFiles(solutionDir);
                    metadata.Tags = metadataFromFiles.Tags;
                    metadata.TimeComplexity = metadataFromFiles.TimeComplexity;
                    metadata.MemoryComplexity = metadataFromFiles.MemoryComplexity;
                }

                break;
            }
            
            return metadata;
        }

        private static string? FindSolutionDirectory(string baseDir, string titleSlug)
        {
            try
            {
                var directories = Directory.GetDirectories(baseDir);
                foreach (var dir in directories)
                {
                    var dirName = Path.GetFileName(dir).ToLower();
                    
                    if (dirName.Contains(titleSlug, StringComparison.CurrentCultureIgnoreCase) || 
                        dirName.Replace("-", "").Contains(titleSlug.ToLower().Replace("-", "")))
                        return dir.Replace("\\", "/");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching directory {baseDir}: {ex.Message}");
            }
            
            return null;
        }

        private static SolutionMetadata ExtractMetadataFromFiles(string directoryPath)
        {
            var metadata = new SolutionMetadata();
            
            try
            {
                var files = Directory.GetFiles(directoryPath, "*.cs");
                
                foreach (var file in files)
                {
                    var content = File.ReadAllText(file);
                    
                    var tagsMatch = Regex.Match(content, @"(?i)(tags?|LeetCodeTags)[\s:=]+\[([^\]]+)\]");
                    if (tagsMatch.Success)
                        metadata.Tags = tagsMatch.Groups[2].Value.Trim();
                    
                    var timeMatch = Regex.Match(content, """(?i)(TimeComplexity|Time)[\s:=]+["']?([^"'\s]+)""");
                    if (timeMatch.Success)
                        metadata.TimeComplexity = timeMatch.Groups[2].Value.Trim();
                    
                    var memoryMatch = Regex.Match(content, """(?i)(MemoryComplexity|Memory|Space)[\s:=]+["']?([^"'\s]+)""");
                    if (memoryMatch.Success)
                        metadata.MemoryComplexity = memoryMatch.Groups[2].Value.Trim();
                    
                    if (!string.IsNullOrEmpty(metadata.Tags) && 
                        !string.IsNullOrEmpty(metadata.TimeComplexity) && 
                        !string.IsNullOrEmpty(metadata.MemoryComplexity))
                        break;
                }
                
                var readmePath = Path.Combine(directoryPath, "README.md");
                if (File.Exists(readmePath))
                {
                    var readmeContent = File.ReadAllText(readmePath);
                    
                    if (string.IsNullOrEmpty(metadata.Tags))
                    {
                        var tagsMatch = Regex.Match(readmeContent, @"(?i)tags?[\s:]+([^\n]+)");
                        if (tagsMatch.Success) metadata.Tags = tagsMatch.Groups[1].Value.Trim();
                    }
                    
                    if (string.IsNullOrEmpty(metadata.TimeComplexity))
                    {
                        var timeMatch = Regex.Match(readmeContent, @"(?i)time[\s-]*complexity[\s:]+([^\n]+)");
                        if (timeMatch.Success) metadata.TimeComplexity = timeMatch.Groups[1].Value.Trim();
                    }
                    
                    if (string.IsNullOrEmpty(metadata.MemoryComplexity))
                    {
                        var memoryMatch = Regex.Match(readmeContent, @"(?i)memory[\s-]*complexity[\s:]+([^\n]+)");
                        if (memoryMatch.Success) metadata.MemoryComplexity = memoryMatch.Groups[1].Value.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting metadata from {directoryPath}: {ex.Message}");
            }
            
            if (string.IsNullOrEmpty(metadata.Tags)) 
                metadata.Tags = "—";
            if (string.IsNullOrEmpty(metadata.TimeComplexity))
                metadata.TimeComplexity = "—";
            if (string.IsNullOrEmpty(metadata.MemoryComplexity)) 
                metadata.MemoryComplexity = "—";
            
            return metadata;
        }

        private static async Task SaveStats(LeetCodeStats stats)
        {
            try
            {
                var json = JsonConvert.SerializeObject(stats, Formatting.Indented);
                await File.WriteAllTextAsync("stats.json", json);
                Console.WriteLine("✅ stats.json успешно сохранен");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка при сохранении stats.json: {ex.Message}");
            }
        }

        private static async Task UpdateReadme(LeetCodeStats stats)
        {
            const string readmePath = "README.md";
            var content = await File.ReadAllTextAsync(readmePath);
            
            var statsSection = GenerateStatsSection(stats);
            content = Regex.Replace(
                content,
                @"<!-- STATS_SECTION_START -->[\s\S]*?<!-- STATS_SECTION_END -->",
                statsSection,
                RegexOptions.Singleline
            );
            
            if (stats.RecentSolutions.Count > 0)
            {
                var recentMd = "| Leetcode | Github | Использованные теги | Time Complexity | Memory Complexity |\n";
                recentMd += "|----------|--------|-------------------|-----------------|-------------------|\n";
                
                foreach (var sol in stats.RecentSolutions)
                    recentMd += $"| [{sol.Title}](https://leetcode.com/problems/{sol.TitleSlug}/) | {sol.GithubPath} | {sol.Tags} | {sol.TimeComplexity} | {sol.MemoryComplexity} |\n";
                
                content = Regex.Replace(
                    content,
                    @"<!-- RECENT_SOLUTIONS_START -->[\s\S]*?<!-- RECENT_SOLUTIONS_END -->",
                    $"<!-- RECENT_SOLUTIONS_START -->\n{recentMd}\n<!-- RECENT_SOLUTIONS_END -->",
                    RegexOptions.Singleline
                );
            }
            
            content = Regex.Replace(
                content,
                """<span id="last-updated">.*</span>""",
                $"""<span id="last-updated">{stats.UpdatedAt:yyyy-MM-dd HH:mm:ss}</span>"""
            );
            
            await File.WriteAllTextAsync(readmePath, content);
        }

        private static string GenerateStatsSection(LeetCodeStats stats)
        {
            var easyPercent = CalculateProgressPercent(stats.EasySolved, 1000);
            var mediumPercent = CalculateProgressPercent(stats.MediumSolved, 1000);
            var hardPercent = CalculateProgressPercent(stats.HardSolved, 500);
            var totalPercent = CalculateProgressPercent(stats.TotalSolved, 2500);
            
            return $"""
                    <!-- STATS_SECTION_START -->
                    <div align="center">

                    ### 🎯 Прогресс решения задач

                    **Всего решено:** `{stats.TotalSolved}` задач

                    | Сложность | Решено | Прогресс |
                    |-----------|--------|----------|
                    | 🟢 Легкие | `{stats.EasySolved}` | ![](https://geps.dev/progress/{easyPercent}?width=100&color=22c55e) |
                    | 🟡 Средние | `{stats.MediumSolved}` | ![](https://geps.dev/progress/{mediumPercent}?width=100&color=eab308) |
                    | 🔴 Сложные | `{stats.HardSolved}` | ![](https://geps.dev/progress/{hardPercent}?width=100&color=ef4444) |

                    **📈 Общий прогресс:**  
                    ![](https://geps.dev/progress/{totalPercent}?width=300&color=3b82f6)

                    **🏆 Рейтинг:** `{stats.Ranking}`  
                    **🎯 Acceptance Rate:** `{stats.AcceptanceRate}`

                    *Статистика обновляется автоматически ежедневно*

                    </div>
                    <!-- STATS_SECTION_END -->
                    """;
        }

        private static int CalculateProgressPercent(int solved, int max)
        {
            if (max <= 0)
                return 0;
            
            var percent = (int)((double)solved / max * 100);
            
            return Math.Min(Math.Max(percent, 0), 100);
        }
    }
    
    public class LeetCodeStats
    {
        public int TotalSolved { get; set; }
        public int EasySolved { get; set; }
        public int MediumSolved { get; set; }
        public int HardSolved { get; set; }
        public string AcceptanceRate { get; set; } = "0%";
        public string Ranking { get; set; } = "N/A";
        public DateTime UpdatedAt { get; init; }
        public List<RecentSolution> RecentSolutions { get; } = [];
    }
    
    public class RecentSolution
    {
        public string Title { get; init; } = string.Empty;
        public string TitleSlug { get; init; } = string.Empty;
        public string GithubPath { get; init; } = "—";
        public string Tags { get; init; } = "—";
        public string TimeComplexity { get; init; } = "—";
        public string MemoryComplexity { get; init; } = "—";
    }
    
    public class SolutionMetadata
    {
        public string GithubPath { get; set; } = "—";
        public string Tags { get; set; } = "—";
        public string TimeComplexity { get; set; } = "—";
        public string MemoryComplexity { get; set; } = "—";
    }
}