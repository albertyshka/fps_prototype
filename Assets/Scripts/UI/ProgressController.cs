using UnityEngine;

namespace UI
{
	public sealed class ProgressController : MonoBehaviour
	{
#if UNITY_EDITOR
		private float _lastProgress;
#endif
		private Vector2 _initialScale;
		private Vector2 _initialMaskSize;

#pragma warning disable 649
		[SerializeField] private SpriteRenderer _bar;
		[SerializeField] private SpriteMask _mask;
		[SerializeField, Range(0f, 1f)] private float _progress = 0.5f;
#pragma warning restore 649

		public float Progress
		{
			get => _progress;
			set

			{
				if (value.Equals(_progress)) return;
				_progress = value;
				UpdateProgress();
			}
		}

		private void Start()
		{
#if UNITY_EDITOR
			_lastProgress = _progress;
#endif
			var s = _mask.sprite;
			var sz = s.rect.size / s.pixelsPerUnit;
			_initialScale = _mask.transform.localScale;
			_initialMaskSize = new Vector2(sz.x * _initialScale.x, sz.y * _initialScale.y);

			UpdateProgress();
		}

#if UNITY_EDITOR
		private void Update()
		{
			if (!_lastProgress.Equals(_progress))
			{
				_lastProgress = _progress;
				UpdateProgress();
			}
		}
#endif

		private void UpdateProgress()
		{
			var progress = Mathf.Clamp01(_progress);
			if (progress >= 0.99f)
			{
				_mask.gameObject.SetActive(false);
				return;
			}

			_mask.gameObject.SetActive(true);

			var t = _mask.transform;
			t.localPosition = new Vector3(_initialMaskSize.x * 0.5f * progress, 0, 0);
			t.localScale = new Vector3(_initialScale.x * (1f - progress), _initialScale.y, 1f);
		}
	}
}