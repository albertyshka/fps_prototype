using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeaponOnCollision : MonoBehaviour
{
	[SerializeField] private ParticleSystem _particleSystem;

	public event Action<ParticleCollisionEvent> OnParticleCollisionEvent;

	private List<ParticleCollisionEvent> _collisionEvents = new List<ParticleCollisionEvent>();


	private void OnParticleCollision(GameObject other)
	{
		ParticlePhysicsExtensions.GetCollisionEvents(_particleSystem, other, _collisionEvents);

		for (int i = 0; i < _collisionEvents.Count; i++)
		{
			var collisionEvent = _collisionEvents[i];

			OnParticleCollisionEvent?.Invoke(collisionEvent);
		}
	}
}
