using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuff", menuName = "Common/Buff")]
public class BuffSO : ScriptableObject
{
    public BuffType type;
    public BuffApplyType appplyType;
    public float amount;
    public float duration;
}
