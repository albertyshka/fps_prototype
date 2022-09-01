using System;

public class FireBuff : IBuff
{
	private readonly int _damagePerSecond;
	private readonly int _startDamage;
	private readonly int _dryDamage;

	private IDisposable _removeDisposable;

	private int _duration;
	public int Duration 
	{ 
		get => _duration;
		set => _duration = value; 
	}

	public int DryDamage => _dryDamage;

	public FireBuff(int duration, int damagePerSecond, int dryDamage)
	{
		_duration = duration;
		_damagePerSecond = damagePerSecond;
		_dryDamage = dryDamage;
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
				_removeDisposable?.Dispose();
				break;
			case FireBuff fireBuff:
				// восстановить огонь
				_duration = fireBuff.Duration;
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
