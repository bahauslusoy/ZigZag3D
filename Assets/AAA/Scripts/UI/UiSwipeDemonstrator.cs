using DG.Tweening;
using UnityEngine;

namespace EasyClap.SnakeRush3D.Ui
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(RectTransform))]
    public class UiSwipeDemonstrator : MonoBehaviour
    {
        [SerializeField] private float fadeInDuration;
        [SerializeField] private float fadeOutDuration;
        [SerializeField] private float moveDuration;
        [SerializeField] private float endWaitDuration;
        [SerializeField] private float firstMoveTargetX;
        [SerializeField] private float secondMoveTargetX;

        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private Sequence _sequence;

        void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();

            // start invisible
            _canvasGroup.alpha = 0f;

            _sequence = DOTween.Sequence();

            // fade in
            _sequence.Append(_canvasGroup.DOFade(1f, fadeInDuration));

            // first move
            _sequence.Append(_rectTransform.DOLocalMoveX(firstMoveTargetX, moveDuration));

            // second move
            _sequence.Append(_rectTransform.DOLocalMoveX(secondMoveTargetX, moveDuration * 2f));

            // fade out
            _sequence.Append(_canvasGroup.DOFade(0f, fadeOutDuration));

            // snap to center
            _sequence.Append(_rectTransform.DOLocalMoveX(0f, 0f));

            // wait
            _sequence.AppendInterval(endWaitDuration);

            _sequence.SetLoops(-1);

            _sequence.Play();
        }
    }
}
