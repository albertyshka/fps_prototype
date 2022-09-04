using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buff
{
    [CreateAssetMenu(fileName = "NewFireBuff", menuName = "Common/FireBuff")]
    public class FireBuffSO : BuffSO
    {
        public int Duration;
        public int DamagePerSecond;
        public int Damage;
    }
}
