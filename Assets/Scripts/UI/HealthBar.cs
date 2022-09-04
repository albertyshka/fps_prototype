using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

namespace UI
{

	public class HealthBar : MonoBehaviour
	{
		[SerializeField] private NpcStatController _npcStatController;
		[SerializeField] private ProgressController _progressController;
		[SerializeField] private TextMeshPro _text;
		[SerializeField] private float _maxValue;

		private void Start()
		{
			_npcStatController.OnHealthPointsChange += UpdateView;
			UpdateView(1000);
		}

		private void OnDestroy()
		{
			_npcStatController.OnHealthPointsChange -= UpdateView;
		}

		private void UpdateView(int health)
		{
			_text.text = $"{health}/{_maxValue}";
			_progressController.Progress = health / _maxValue;
		}
	}
}
