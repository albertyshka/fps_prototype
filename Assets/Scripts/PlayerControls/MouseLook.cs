using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
	public class MouseLook : MonoBehaviour
	{
		[SerializeField] private float _mouseSensitivity = 100f;
		[SerializeField] private Vector2 _minMaxMouseXRotation;
		[SerializeField] private Transform _playerTransform;

		private float _mouseInputX;
		private float _mouseInputY;
		private float _xRotation;

		private void Start()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void Update()
		{
			_mouseInputX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
			_mouseInputY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

			_xRotation -= _mouseInputY;
			_xRotation = Mathf.Clamp(_xRotation, _minMaxMouseXRotation.x, _minMaxMouseXRotation.y);

			transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
			_playerTransform.Rotate(Vector3.up * _mouseInputX);
		}
	}
}

