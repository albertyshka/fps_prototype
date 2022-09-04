using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBuffApplyer : MonoBehaviour
{
    [SerializeField] private BuffProvider _buffProvider;
    [SerializeField] private string _enemyTag;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == _enemyTag)
		{
			var statsHolder = other.transform.root.GetComponent<NpcStatController>() as INpcStatsHolder;
			_buffProvider.ApplyBuff(statsHolder);
		}

		Destroy(this.gameObject);
	}
}
