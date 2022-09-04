using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeaponFire : WeaponFire
{
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private string _enemyTag;
    [SerializeField] private BuffProvider _buffProvider;

	private RaycastHit _hit;
	private Coroutine _showLineCoroutine;

	public override void Fire()
	{
		Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

		if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out _hit, 1000f))
		{
			if (_hit.collider != null && _hit.collider.tag == _enemyTag)
			{
				var npcStatsHolder = _hit.collider.transform.root.gameObject.GetComponent<NpcStatController>() as INpcStatsHolder;
				
				if (npcStatsHolder != null)
				{
					_buffProvider.ApplyBuff(npcStatsHolder);
				}

				_lineRenderer.enabled = true;
			}
		}

		if (_showLineCoroutine != null)
		{
			StopCoroutine(_showLineCoroutine);
			_showLineCoroutine = null;
		}
		_showLineCoroutine = StartCoroutine("ShowLine");
	}

	private IEnumerator ShowLine()
	{
		_lineRenderer.enabled = true;
		yield return new WaitForSeconds(0.1f);
		_lineRenderer.enabled = false;
	}
}
