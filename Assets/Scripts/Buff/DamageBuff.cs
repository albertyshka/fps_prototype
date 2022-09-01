using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : IBuff
{
	public int Damage;

	public int Duration { get => 0; set { } }

	public DamageBuff(int damage)
	{
		Damage = damage;
	}

	public void ApplyStatChange(ref IBuff buff) { }

	void IBuff.OnStartUp(INpcStatsHolder stats)
	{
		stats.HealthPoints -= Damage;
	}

	void IBuff.OnTearDown(INpcStatsHolder stats) { }

	void IBuff.OnTick(INpcStatsHolder stats) { }
}
