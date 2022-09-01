using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : IBuff
{
	private readonly bool _isStackable;

	int IBuff.Duration { get => 0; set { } }
	bool IBuff.IsReadyToBeRemoved => true;
	bool IBuff.IsStackable => _isStackable;

	public int Damage;

	public DamageBuff(int damage, bool isStackable)
	{
		Damage = damage;
		_isStackable = isStackable;
	}

	void IBuff.ApplyStatChange(ref IBuff buff) { }

	void IBuff.OnStartUp(INpcStatsHolder stats)
	{
		stats.HealthPoints -= Damage;
	}

	void IBuff.OnTearDown(INpcStatsHolder stats) { }

	void IBuff.OnTick(INpcStatsHolder stats) { }
}
