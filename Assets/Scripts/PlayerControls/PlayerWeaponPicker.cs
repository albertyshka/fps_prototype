using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerController
{
    public enum Hand
	{
        Right,
        Left
	}

    public class PlayerWeaponPicker : MonoBehaviour
    {
		[Header("Common")]
        [SerializeField] private Transform _leftArm;
        [SerializeField] private Transform _rightArm;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _pickUpRange;
        [SerializeField] private string _weaponTag;
        [SerializeField] private float _pullForce;

        [Header("UI")]
        [SerializeField] private Image _uiPointer;
        [SerializeField] private Color _pickUpColor;
        [SerializeField] private Color _defaultColor;

        [Header("Controlls")]
        [SerializeField] private KeyCode _leftHandPickUp;
        [SerializeField] private KeyCode _rightHandPickUp;

        private Weapon _leftArmWeapon;
        private Weapon _rightArmWeapon;

        private RaycastHit _hit;

        void Update()
        {
            Vector3 rayOrigin = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            if (Physics.Raycast(rayOrigin, _camera.transform.forward, out _hit, 1000f))
            {
                if (_hit.collider != null && _hit.collider.tag == _weaponTag)
                {
                    _uiPointer.color = _pickUpColor;
                }
                else
                {
                    _uiPointer.color = _defaultColor;
                }
            }

            if (Input.GetKeyDown(_leftHandPickUp))
            {
                ToggleWeapon(Hand.Left);
            }

            if (Input.GetKeyDown(_rightHandPickUp))
            {
                ToggleWeapon(Hand.Right);
            }
        }

		private void ToggleWeapon(Hand hand)
        {
            void toggleWeaponInArm(ref Weapon weapon, Transform arm)
			{
                if (weapon)
                {
                    // drop weapon
                    weapon.RemoveFromArm();
                    weapon = null;
                }
                else if (_hit.collider != null && _hit.collider.tag == _weaponTag)
                {
                    // pick up weapon
                    weapon = _hit.collider.GetComponentInParent<Weapon>();
                    weapon.PlaceInArm(arm);
                }
            }

            switch (hand)
			{
                case Hand.Left:
                    toggleWeaponInArm(ref _leftArmWeapon, _leftArm);
                    break;
                case Hand.Right:
                    toggleWeaponInArm(ref _rightArmWeapon, _rightArm);
                    break;
                default:
                    throw new NotImplementedException();
			}
        }
    }
}
