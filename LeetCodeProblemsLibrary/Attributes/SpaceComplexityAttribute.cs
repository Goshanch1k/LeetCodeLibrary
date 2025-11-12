using System.ComponentModel;

namespace LeetCodeProblemsLibrary.Attributes;

public class SpaceComplexityAttribute(params string[] tags) : DescriptionAttribute($"Tags: {string.Join(",", tags)}");