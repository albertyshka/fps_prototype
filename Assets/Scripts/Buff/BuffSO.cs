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
    public NpcProperty Stat;
    [ShowIf("Stat", NpcProperty.Buff)]
    [LabelWidth(50), HorizontalGroup("B")]
    public string BuffId;
    [HideIf("Stat", NpcProperty.Buff)]
    [LabelWidth(50), HorizontalGroup("B")]
    public float Amount;
}

/*
 * эффект, continuous (сколько то секунд)
 * влияет на входящие значения урона (мокрость или hp)
 * 
 * эффекты: мокрость, горение
 */
