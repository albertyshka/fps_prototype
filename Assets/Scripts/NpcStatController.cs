using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class NpcStatController : MonoBehaviour, INpcStatsHolder
{
	public LinkedList<IBuff> _buffs = new LinkedList<IBuff>();

	[SerializeField] private int _startHP = 1000;

	private readonly CompositeDisposable _disposables = new CompositeDisposable();
	private int _healthPoints;

	LinkedList<IBuff> INpcStatsHolder.Buffs => _buffs;
	int INpcStatsHolder.HealthPoints 
	{ 
		get => _healthPoints;
		set => _healthPoints = value;
	}

	private void Start()
	{
		_healthPoints = _startHP;

		// производить каждую секунду
		Observable.Interval(TimeSpan.FromSeconds(1f))
			.Subscribe(second =>
			{
				for (int i = _buffs.Count - 1; i >= 0; i--)
				{
					var buff = _buffs.ElementAt(i);
					_buffs.ElementAt(i).OnTick(this);

					buff.Duration -= 1;
					if (buff.Duration <= 0) RemoveBuff(buff);
				}
			});
	}

	private void OnDestroy()
	{
		_disposables.Dispose();
	}

	public void ApplyBuff(IBuff newBuff)
	{
		for (int i = _buffs.Count - 1; i >= 0; i--)
		{
			var buff = _buffs.ElementAt(i);
			buff.ApplyStatChange(ref newBuff);
		}

		throw new NotImplementedException();

		/*switch (buff)
		{
			case FireBuff fireBuff:
				fireBuff.ApplyStatChange();
				break;
			case WaterBuff fireBuff:
				break;
		}*/
	}

	private void AddBuff(IBuff buff)
	{
		buff.OnStartUp(this);
		_buffs.AddLast(buff);
	}

	private void RemoveBuff(IBuff buff)
	{
		buff.OnTearDown(this);
		_buffs.Remove(buff);
	}
}
