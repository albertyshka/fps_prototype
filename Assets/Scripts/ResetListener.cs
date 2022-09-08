using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetListener : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
		{
            foreach (var g in FindObjectsOfType<NpcStatController>())
			{
                Destroy(g.gameObject);
            }

            Instantiate(_prefab);
		}
    }
}
