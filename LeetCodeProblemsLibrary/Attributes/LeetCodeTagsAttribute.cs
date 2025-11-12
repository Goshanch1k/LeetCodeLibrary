using System.ComponentModel;

namespace LeetCodeProblemsLibrary.Attributes;

public class LeetCodeTagsAttribute(params string[] tags) : DescriptionAttribute($"Tags: {string.Join(",", tags)}");