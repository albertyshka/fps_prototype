using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buff
{
    [CreateAssetMenu(fileName = "NewDamageBuff", menuName = "Common/DamageBuff")]
    public class DamageBuffSO : BuffSO
    {
        public int Damage;
    }
}
