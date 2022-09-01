using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuff", menuName = "Common/Buff")]
public class BuffSO : SerializedScriptableObject
{
    [LabelWidth(80)]
    public string Id;    
	[LabelWidth(80), HorizontalGroup("A")]
    public BuffApplyType ApplyType;
	[ShowIf("ApplyType", BuffApplyType.Continuous)]
    [LabelWidth(50), HorizontalGroup("A")]
    public float Duration;

    [LabelWidth(80), HorizontalGroup("B")]
    public BuffStatType Stat;
    [LabelWidth(50), HorizontalGroup("B")]
    public float Amount;
}
