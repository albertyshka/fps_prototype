using System;

namespace Condition
{
	[Flags]
	public enum Comparison
	{
		Equals = 0x01,
		Less = 0x02,
		More = 0x04
	}

	public static class ComparisionHelper
	{
		public static Comparison ToComparison(this string s)
		{
			return s.Trim() switch
			{
				"=" => Comparison.Equals,
				"<" => Comparison.Less,
				">" => Comparison.More,
				"<=" => Comparison.Equals | Comparison.Less,
				">=" => Comparison.Equals | Comparison.More,
				_ => throw new NotSupportedException($"Can't convert \"{s}\" to valid comparision.")
			};
		}
	}
}