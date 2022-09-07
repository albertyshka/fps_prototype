using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buff
{
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

		bool IBuff.ApplyStatChange(ref IBuff buff) => true;

		void IBuff.OnStartUp(INpcStatsHolder stats)
		{
			Debug.Log($"DamageBuff deal initial damage {Damage}");
			stats.HealthPoints -= Damage;
		}

		void IBuff.OnTearDown(INpcStatsHolder stats) { }

		void IBuff.OnTick(INpcStatsHolder stats) { }
	}
}
