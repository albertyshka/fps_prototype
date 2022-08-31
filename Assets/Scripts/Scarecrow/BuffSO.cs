using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuff", menuName = "Common/Buff")]
public class BuffSO : SerializedScriptableObject
{
	[LabelWidth(80), HorizontalGroup("A")]
    public BuffApplyType applyType;
	[ShowIf("applyType", BuffApplyType.Continuous)]
    [LabelWidth(50), HorizontalGroup("A")]
    public float duration;

    [LabelWidth(80), HorizontalGroup("B")]
    public BuffType type;
    [LabelWidth(50), HorizontalGroup("B")]
    public float amount;
}
