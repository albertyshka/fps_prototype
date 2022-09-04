using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponFire : WeaponFire
{
    [SerializeField] private Rigidbody _projectile;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _launchForce;

	public override void Fire()
	{
		var instanceRb = Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);
		instanceRb.AddForce(transform.forward * _launchForce, ForceMode.Impulse);
	}
}
