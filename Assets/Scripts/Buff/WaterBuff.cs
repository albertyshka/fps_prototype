using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBuff : IBuff
{
	private readonly int _maxWetnessAmount;
	private int _wetnessAmount;

	public int Duration { get => 1; set { } }
	public int Amount 
	{ 
		get => _wetnessAmount; 
		set => _wetnessAmount = value; 
	}

	public WaterBuff(int amount, int maxAmount)
	{
		_wetnessAmount = amount;
		_maxWetnessAmount = maxAmount;
	}

	public void ApplyStatChange(ref IBuff buff)
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

	public void OnStartUp(INpcStatsHolder stats) { }
	public void OnTearDown(INpcStatsHolder stats) { }
	public void OnTick(INpcStatsHolder stats) { }
}
