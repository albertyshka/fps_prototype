using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Condition
{
	[CreateAssetMenu(fileName = "NewCompareCondition", menuName = "Common/CompareCondition")]
	public class CompareCondition : Condition
	{
		[HorizontalGroup, HideLabel]
		public NpcProperty npcProperty;
		[HorizontalGroup, HideLabel]
		public Comparison comparison;
		[HorizontalGroup, HideLabel]
		public string value;

		public override bool Check()
		{
			return false;
		}
	}
}