using UnityEngine.Assertions;
using Zenject;

namespace Condition
{
	public class NotCondition : Condition
	{
		private readonly Condition _initialCondition;

		public NotCondition(Condition initialCondition)
		{
			Assert.IsNotNull(initialCondition);
			_initialCondition = initialCondition;
		}

		public override bool Check()
		{
			return !_initialCondition.Check();
		}
	}
}