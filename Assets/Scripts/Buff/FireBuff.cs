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

		bool IBuff.ApplyStatChange(ref IBuff buff)
		{
			var result = false;

			switch (buff)
			{
				case DamageBuff damageBuff:
					Debug.Log($"FireBuff change DamageBuff damage {damageBuff.Damage} by 10");
					damageBuff.Damage += 10;
					result = true;
					break;
				case WaterBuff waterBuff:
					// удалить огненный баф
					Debug.Log($"FireBuff change WaterBuff delete itself");
					_duration = 0;
					result = true;
					break;
				case FireBuff fireBuff:
					// восстановить огонь
					Debug.Log($"FireBuff change FireBuff restore time");
					_duration = buff.Duration;
					break;
				default:
					throw new NotImplementedException();
			}

			return result;
		}

		void IBuff.OnTearDown(INpcStatsHolder stats) { }

		void IBuff.OnStartUp(INpcStatsHolder stats)
		{
			Debug.Log($"FireBuff deal initial damage {_startDamage}");
			stats.HealthPoints -= _startDamage;
		}

		void IBuff.OnTick(INpcStatsHolder stats)
		{
			Debug.Log($"FireBuff deal overtime damage {_damagePerSecond}");
			stats.HealthPoints -= _damagePerSecond;
		}

		public object Clone()
		{
			return new FireBuff(_duration, _isStackable, _damagePerSecond, _startDamage);
		}
	}
}
