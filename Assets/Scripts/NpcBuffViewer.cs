using Buff;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBuffViewer : MonoBehaviour
{
    [SerializeField] private NpcStatController _npcStatController;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _wetMaterial;
    [SerializeField] private Material _onFireMaterial;
    [SerializeField] private Material _defaultMaterial;

	private void Start()
	{
		_npcStatController.OnBuffAdded += OnBuffAddedHandler;
		_npcStatController.OnBuffRemoved += OnBuffRemovedHandler;
	}

	private void OnDestroy()
	{
		_npcStatController.OnBuffAdded -= OnBuffAddedHandler;
		_npcStatController.OnBuffRemoved -= OnBuffRemovedHandler;
	}

	public void OnBuffRemain(IBuff buff)
	{
		switch (buff)
		{
			case DamageBuff damageBuff:
				break;
			case WaterBuff waterBuff:
				_meshRenderer.material = _wetMaterial;
				break;
			case FireBuff fireBuff:
				_meshRenderer.material = _onFireMaterial;
				break;
			default:
				throw new NotImplementedException();
		}
	}

	private void OnBuffAddedHandler(IBuff buff)
	{
		switch (buff)
		{
			case DamageBuff damageBuff:
				break;
			case WaterBuff waterBuff:
				_meshRenderer.material = _wetMaterial;
				break;
			case FireBuff fireBuff:
				_meshRenderer.material = _onFireMaterial;
				break;
			default:
				throw new NotImplementedException();
		}
	}

	private void OnBuffRemovedHandler(IBuff buff)
	{
		switch (buff)
		{
			case DamageBuff damageBuff:
				break;
			case WaterBuff waterBuff:
				_meshRenderer.material = _defaultMaterial;
				break;
			case FireBuff fireBuff:
				_meshRenderer.material = _defaultMaterial;
				break;
			default:
				throw new NotImplementedException();
		}
	}
}
