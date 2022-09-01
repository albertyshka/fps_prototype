using System;

public class FireBuff : IBuff
{
	private readonly int _damagePerSecond;
	private readonly int _startDamage;
	private readonly int _dryDamage;
	private readonly bool _isStackable;
	private int _duration;

	int IBuff.Duration
	{ 
		get => _duration; 
		set => _duration = value; 
	}
	bool IBuff.IsReadyToBeRemoved => _duration <= 0;
	bool IBuff.IsStackable => _isStackable;

	public int DryDamage => _dryDamage;


	public FireBuff(int duration, bool isStackable, int damagePerSecond, int dryDamage)
	{
		_duration = duration;
		_damagePerSecond = damagePerSecond;
		_dryDamage = dryDamage;
		_isStackable = isStackable;
	}

	public void ApplyStatChange(ref IBuff buff)
	{
		switch (buff)
		{
			case DamageBuff damageBuff:
				damageBuff.Damage += 10;
				break;
			case WaterBuff:
				// удалить огненный баф
				_duration = 0;
				break;
			case FireBuff:
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
