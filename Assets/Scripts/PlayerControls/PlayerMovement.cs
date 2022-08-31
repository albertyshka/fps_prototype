using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
    public class PlayerMovement : MonoBehaviour
    {
		[SerializeField] private float _speed = 12f;
		[SerializeField] private CharacterController _controller;

		private void Update()
		{
			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");

			Vector3 move = transform.right * x + transform.forward * z;

			_controller.Move(move * _speed * Time.deltaTime);
		}
	}
}
