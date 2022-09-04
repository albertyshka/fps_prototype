using System;
using UnityEngine;

namespace Buff
{
	public class FireBuff : IBuff
	{
		private readonly int _damagePerSecond;
		private readonly int _startDamage;
		private readonly bool _isStackable;
		private int _duration;

		int IBuff.Duration
		{
			get => _duration;
			set => _duration = value;
		}
		bool IBuff.IsReadyToBeRemoved => _duration <= 0;
		bool IBuff.IsStackable => _isStackable;

		public FireBuff(int duration, bool isStackable, int damagePerSecond, int startDamage)
		{
			_duration = duration;
			_damagePerSecond = damagePerSecond;
			_startDamage = startDamage;
			_isStackable = isStackable;
		}

		public void ApplyStatChange(ref IBuff buff)
		{
			switch (buff)
			{
				case DamageBuff damageBuff:
					damageBuff.Damage += 10;
					break;
				case WaterBuff waterBuff:
					// удалить огненный баф
					_duration = 0;
					break;
				case FireBuff fireBuff:
					// восстановить огонь
					_duration = buff.Duration;
					break;
				default:
					throw new NotImplementedException();
			}
		}

		void IBuff.OnTearDown(INpcStatsHolder stats) { }

		void IBuff.OnStartUp(INpcStatsHolder stats)
		{
			stats.HealthPoints -= _startDamage;
		}

		void IBuff.OnTick(INpcStatsHolder stats)
		{
			stats.HealthPoints -= _damagePerSecond;
		}
	}
}
