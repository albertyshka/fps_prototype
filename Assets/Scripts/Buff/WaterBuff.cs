using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buff
{
	public class WaterBuff : IBuff
	{
		private readonly int _maxWetnessAmount;
		private readonly bool _isStackable;
		private int _wetnessAmount;

		int IBuff.Duration { get => 1; set { } }
		bool IBuff.IsReadyToBeRemoved => _wetnessAmount <= 0;
		bool IBuff.IsStackable => _isStackable;

		public int Amount
		{
			get => _wetnessAmount;
			set => _wetnessAmount = value;
		}

		public WaterBuff(int amount, int maxAmount, bool isStackable)
		{
			_wetnessAmount = amount;
			_maxWetnessAmount = maxAmount;
			_isStackable = isStackable;
		}

		bool IBuff.ApplyStatChange(ref IBuff buff)
		{
			var result = false;
			switch (buff)
			{
				case DamageBuff damageBuff:
					Debug.Log($"WaterBuff change DamageBuff damage {damageBuff.Damage} by -10");
					damageBuff.Damage -= 10;
					result = true;
					break;
				case WaterBuff waterBuff:
					Debug.Log($"WaterBuff change WaterBuff _wetnessAmount {_wetnessAmount} by {waterBuff.Amount}");
					_wetnessAmount += waterBuff.Amount;
					break;
				case FireBuff fireBuff:
					Debug.Log($"WaterBuff change FireBuff _wetnessAmount {_wetnessAmount} by {-1}");
					_wetnessAmount -= 1;
					break;
				default:
					throw new NotImplementedException();
			}
			_wetnessAmount = Mathf.Min(_wetnessAmount, _maxWetnessAmount);
			return result;
		}

		void IBuff.OnStartUp(INpcStatsHolder stats) { }
		void IBuff.OnTearDown(INpcStatsHolder stats) { }
		void IBuff.OnTick(INpcStatsHolder stats) { }

		public object Clone()
		{
			return new WaterBuff(_wetnessAmount, _maxWetnessAmount, _isStackable);
		}
	}
}
