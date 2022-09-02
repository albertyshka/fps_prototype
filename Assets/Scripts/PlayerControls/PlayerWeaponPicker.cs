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
        [SerializeField] private GameObject _leftArm;
        [SerializeField] private GameObject _rightArm;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _pickUpRange;
        [SerializeField] private string _weaponTag;

        [Header("UI")]
        [SerializeField] private Image _uiPointer;
        [SerializeField] private Color _pickUpColor;
        [SerializeField] private Color _defaultColor;

        [Header("Controlls")]
        [SerializeField] private KeyCode _leftHandPickUp;
        [SerializeField] private KeyCode _rightHandPickUp;

        private GameObject _leftArmWeapon;
        private GameObject _rightArmWeapon;

        private RaycastHit _hit;

        void Update()
        {
            Vector3 rayOrigin = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            if (Physics.Raycast(rayOrigin, _camera.transform.forward, out _hit, 1000f))
            {
                if (_hit.collider.tag == _weaponTag)
                {
                    _uiPointer.color = _pickUpColor;
                }
                else
                {
                    _uiPointer.color = _defaultColor;
                }
            }

            if (Input.GetKey(_leftHandPickUp)) ToggleWeapon(Hand.Left);
            if (Input.GetKey(_rightHandPickUp)) ToggleWeapon(Hand.Right);
        }

        private void ToggleWeapon(Hand hand)
        {
            var weaponTransform = _hit.collider.transform.parent;

            switch (hand)
			{
                case Hand.Left:
                    if (_leftArmWeapon)
					{
                        // drop weapon
					}
                    else
					{
                        // pick up weapon
                    }

                    break;
                case Hand.Right:
                    break;
                default:
                    break;
			}
        }
    }
}
