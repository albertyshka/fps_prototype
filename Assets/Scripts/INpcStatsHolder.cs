using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface INpcStatsHolder
{
    int HealthPoints { get; set; }
    public LinkedList<IBuff> Buffs { get; }
}
