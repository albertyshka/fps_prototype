using Zenject;

namespace Condition
{
	public class AndCondition : Condition
	{
		private readonly Condition _condition1;
		private readonly Condition _condition2;

		public AndCondition(Condition condition1, Condition condition2)
		{
			_condition1 = condition1;
			_condition2 = condition2;
		}

		public override bool Check()
		{
			return _condition1.Check() && _condition2.Check();
		}
	}
}