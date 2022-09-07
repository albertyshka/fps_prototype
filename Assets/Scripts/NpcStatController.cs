using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;
using Buff;
using Zenject;

public class NpcStatController : MonoBehaviour, INpcStatsHolder
{
	[SerializeField] private int _startHP = 1000;

	private LinkedList<IBuff> _buffs = new LinkedList<IBuff>();
	private readonly CompositeDisposable _disposables = new CompositeDisposable();
	private int _healthPoints;

	public event Action<int> OnHealthPointsChange;

	LinkedList<IBuff> INpcStatsHolder.Buffs => _buffs;
	int INpcStatsHolder.HealthPoints
	{ 
		get
		{
			return _healthPoints;
		}
		set
		{
			Debug.Log($"OnHealthPointsChange, diff: {_healthPoints - value}");
			OnHealthPointsChange?.Invoke(value);
			_healthPoints = value;
		}
	}

	public void Start()
	{
		_healthPoints = _startHP;

		// производить каждую секунду
		Observable.Interval(TimeSpan.FromSeconds(1f))
			.Subscribe(second =>
			{
				for (int i = _buffs.Count - 1; i >= 0; i--)
				{
					// применяем эффекты всех активных бафов
					var buff = _buffs.ElementAt(i);
					_buffs.ElementAt(i).OnTick(this);

					// уменьшаем время бафа, если он не моментальный
					buff.Duration -= 1;

					// если баф может быть удален, удаляем его
					if (buff.IsReadyToBeRemoved) RemoveBuff(buff);
				}
			}).AddTo(_disposables);
	}

	private void OnDestroy()
	{
		_disposables.Dispose();
	}

	/// <summary>
	/// Применить баф к npc.
	/// </summary>
	/// <param name="newBuff">Баф, который будет применен к npc.</param>
	public void ApplyBuff(IBuff newBuff)
	{
		for (int i = _buffs.Count - 1; i >= 0; i--)
		{
			var buff = _buffs.ElementAt(i);
			buff.ApplyStatChange(ref newBuff);
		}

		var canAdd = _buffs.Contains(newBuff) ? newBuff.IsStackable : true;
		if (canAdd)
		{
			AddBuff(newBuff);
		}
		else
		{
			newBuff.OnStartUp(this);
			newBuff.OnTearDown(this);
		}
	}

	private void AddBuff(IBuff buff)
	{
		Debug.Log($"AddBuff: {buff}");
		buff.OnStartUp(this);
		_buffs.AddLast(buff);
	}

	private void RemoveBuff(IBuff buff)
	{
		Debug.Log($"RemoveBuff: {buff}");
		buff.OnTearDown(this);
		_buffs.Remove(buff);
	}
}
