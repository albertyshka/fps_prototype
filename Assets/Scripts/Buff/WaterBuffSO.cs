using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buff
{
    [CreateAssetMenu(fileName = "NewWaterBuff", menuName = "Common/WaterBuff")]
    public class WaterBuffSO : BuffSO
    {
        public int WetnessAmount;
        public int MaxWetnessAmount;
    }
}
