using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Condition;

namespace Condition
{
	public abstract class Condition : SerializedScriptableObject
	{
		public abstract bool Check();
	}

	public enum Operation
	{
		None,
		And,
		Or,
		Not
	}
}