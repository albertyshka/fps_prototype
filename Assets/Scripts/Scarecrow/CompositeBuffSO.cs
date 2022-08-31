using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCompositeBuff", menuName = "Common/CompositeBuff")]
public class CompositeBuffSO : ScriptableObject
{
    public BuffSO _startBuff;
    public BuffSO _continuousBuff;
    public BuffSO _endBuff;
}
