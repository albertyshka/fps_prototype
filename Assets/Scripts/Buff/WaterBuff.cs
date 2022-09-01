using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}

	void IBuff.ApplyStatChange(ref IBuff buff)
	{
		switch (buff)
		{
			case DamageBuff damageBuff:
				damageBuff.Damage -= 10;
				break;
			case WaterBuff waterBuff:
				_wetnessAmount += waterBuff.Amount;
				break;
			case FireBuff fireBuff:
				_wetnessAmount -= fireBuff.DryDamage;
				break;
			default:
				throw new NotImplementedException();
		}

		_wetnessAmount = Mathf.Min(_wetnessAmount, _maxWetnessAmount);
	}

	void IBuff.OnStartUp(INpcStatsHolder stats) { }
	void IBuff.OnTearDown(INpcStatsHolder stats) { }
	void IBuff.OnTick(INpcStatsHolder stats) { }
}
