using System.ComponentModel;

namespace LeetCodeProblemsLibrary.Attributes;

internal class TimeComplexityAttribute(params string[] tags) : DescriptionAttribute($"Tags: {string.Join(",", tags)}");