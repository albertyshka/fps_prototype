using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeaponFire : WeaponFire
{
	[SerializeField] private BuffProvider _buffProvider;
	[SerializeField] private ParticleSystem _particleSystem;
	[SerializeField] private string _enemyTag;
	[SerializeField] private ParticleWeaponOnCollision _onCollisionHandler;

	private void Start()
	{
		_onCollisionHandler.OnParticleCollisionEvent += OnParticleCollisionEvent;
	}

	private void OnDestroy()
	{
		_onCollisionHandler.OnParticleCollisionEvent -= OnParticleCollisionEvent;
	}

	public override void Fire()
	{
        _particleSystem.Emit(1);
    }

    private void OnParticleCollisionEvent(ParticleCollisionEvent pEvent)
	{
        if (pEvent.colliderComponent.tag == _enemyTag)
		{
            var statsHolder = pEvent.colliderComponent.transform.root
                .GetComponent<NpcStatController>() as INpcStatsHolder;
            _buffProvider.ApplyBuff(statsHolder);
        }
	}
}
