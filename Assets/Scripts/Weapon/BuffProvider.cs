using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Buff;
using System;

public class BuffProvider : MonoBehaviour
{
    [SerializeField] private BuffSO _buffSO;

	private IBuff _buff;

	private void Start()
	{
		switch (_buffSO)
		{
			case DamageBuffSO damageBuff:
				_buff = new DamageBuff(damageBuff.Damage, damageBuff.IsStackable);
				break;
			case WaterBuffSO waterBuff:
				_buff = new WaterBuff(waterBuff.WetnessAmount, waterBuff.MaxWetnessAmount, waterBuff.IsStackable);
				break;
			case FireBuffSO fireBuff:
				_buff = new FireBuff(fireBuff.Duration, fireBuff.IsStackable, fireBuff.DamagePerSecond, fireBuff.Damage);
				break;
			default:
				throw new NotSupportedException();
		}
	}

	public void ApplyBuff(INpcStatsHolder statHolder)
	{
		statHolder.ApplyBuff(_buff);
	}
}
