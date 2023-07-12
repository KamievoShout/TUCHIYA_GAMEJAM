using UnityEngine;
using DG.Tweening;

namespace MoveFloors
{
    public class MoveFloorMover : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _targetPos = Vector3.zero;

        [SerializeField]
        private float _tweenTime = 0.0f;

        [SerializeField]
        private Ease _easeType = Ease.Linear;

        private void Start()
        {
            transform.DOLocalMove(_targetPos, _tweenTime)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(_easeType)
                .SetLink(gameObject);
        }
    }
}
