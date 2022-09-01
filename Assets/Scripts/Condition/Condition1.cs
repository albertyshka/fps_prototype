/*using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.Assertions;
using Zenject;

namespace Settings.Reward.Condition
{
	public abstract class Condition
	{
		private enum Operation
		{
			None,
			And,
			Or,
			Not
		}

		private static readonly Regex ExpressionRx = new Regex(@"([^(?:&&)(?:||)!]+)");
		private static readonly Regex ExpressionBodyRx = new Regex(@"^(\w+)\.(\w+)(?:([<>=])([\w\d]+))?$");
		private static readonly Regex CounterBodyRx = new Regex(@"^(\w+)([<>=])([\d]+)$");

		public static Condition Parse(string rawConditionData)
		{
			if (string.IsNullOrEmpty(rawConditionData) || rawConditionData == "-")
			{
				return new TrueCondition();
			}

			var matches = ExpressionRx.Matches(rawConditionData);
			if (matches.Count <= 0)
			{
				throw new FormatException($"Condition raw data \"{rawConditionData}\" isn't match.");
			}

			var rawDataList = rawConditionData.Split(',');
			if (rawDataList.Length > 1)
			{
				var condition = MakeCondition(matches.GetEnumerator(), rawDataList[0]);
				for (var i = 1; i < rawDataList.Length; ++i)
				{
					condition = new AndCondition(condition,
						MakeCondition(matches.GetEnumerator(), rawDataList[i]));
				}

				return condition;
			}

			return MakeCondition(matches.GetEnumerator(), rawConditionData);
		}

		private static Condition MakeCondition(IEnumerator e, string rawConditionData,
			Condition prevExpression = null, Operation operation = Operation.None)
		{
			if (prevExpression != null)
			{
				switch (operation)
				{
					case Operation.Not:
						return MakeCondition(e, rawConditionData, new NotCondition(prevExpression));
					case Operation.None:
						return prevExpression;
				}
			}

			if (!e.MoveNext())
			{
				Assert.IsNotNull(prevExpression);
				return prevExpression;
			}

			if (e.Current is Match m)
			{
				var expression = ParseExpression(m.Groups[1].Value);
				if (m.Index > 0 && rawConditionData[m.Index - 1] == '!')
				{
					expression = MakeCondition(e, rawConditionData, expression, Operation.Not);
				}

				Operation nextOperation;
				if (rawConditionData.Length - (m.Index + m.Length) >= 2)
				{
					var op = rawConditionData.Substring(m.Index + m.Length, 2);
					nextOperation = op switch
					{
						"&&" => Operation.And,
						"||" => Operation.Or,
						_ => throw new NotSupportedException($"Logical operation \"{op}\" isn't supported.")
					};
				}
				else
				{
					nextOperation = Operation.None;
				}

				switch (operation)
				{
					case Operation.And:
						Assert.IsNotNull(prevExpression, "Must have two operands for the AND operation.");
						return MakeCondition(e, rawConditionData,
							new AndCondition(prevExpression, expression), nextOperation);
					case Operation.Or:
						Assert.IsNotNull(prevExpression, "Must have two operands for the OR operation.");
						return new OrCondition(prevExpression,
							MakeCondition(e, rawConditionData, expression, nextOperation));
					case Operation.None:
						Assert.IsNull(prevExpression, "First entrance only can have None operation here.");
						return expression;
					default:
						throw new AggregateException("Unsupported operation.");
				}
			}

			throw new ArgumentException(
				"MakeCondition must received IEnumerator of System.Text.RegularExpressions.Match.");
		}

		private static Condition ParseExpression(string rawData)
		{
			var m = ExpressionBodyRx.Match(rawData);
			if (!m.Success)
			{
				m = CounterBodyRx.Match(rawData);
				if (!m.Success)
				{
					return new PresetCondition(rawData);
				}

				return new CounterCondition(m.Groups[1].Value, m.Groups[2].Value.ToComparison(),
					int.Parse(m.Groups[3].Value));
			}

			return m.Groups[1].Value switch
			{
				"prep" => new PrepCondition(m.Groups[2].Value),
				"level" => new LevelCondition(m.Groups[2].Value, m.Groups[3].Value.ToComparison(),
					int.Parse(m.Groups[4].Value)),
				"stat" => new StatCondition(m.Groups[2].Value, m.Groups[3].Value.ToComparison(),
					int.Parse(m.Groups[4].Value)),
				"user" => new UserCondition(m.Groups[2].Value, m.Groups[3].Value.ToComparison(),
					m.Groups[4].Value),
				_ => throw new NotSupportedException($"Expression type \"{m.Groups[1].Value}\" isn't supported.")
			};
		}

		public abstract bool Check(DiContainer container);
	}
}*/