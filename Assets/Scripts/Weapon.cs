using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private Collider[] _colliders;
	[SerializeField] private Rigidbody _rb;

	public void PlaceInArm(Transform hand)
	{
		_rb.useGravity = false;
		_rb.velocity = Vector3.zero;
		_rb.angularVelocity = Vector3.zero;

		foreach (var collider in _colliders)
		{
			collider.enabled = false;
		}

		transform.SetParent(hand);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public void RemoveFromArm()
	{
		_rb.useGravity = true;
		foreach (var collider in _colliders)
		{
			collider.enabled = true;
		}

		transform.SetParent(null);
	}
}
