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
        private float _delayTime = 0.0f;

        [SerializeField]
        private Ease _easeType = Ease.Linear;

        private Vector3 _startPosition = Vector3.zero;

        private void Start()
        {
            _startPosition = transform.localPosition;

            FirstMove();
        }

        private void FirstMove()
        {
            transform.DOLocalMove(_targetPos, _tweenTime)
            .SetDelay(_delayTime)
            .SetEase(_easeType)
            .SetLink(gameObject)
            .OnComplete(SecondMove);
        }

        private void SecondMove()
        {
            transform.DOLocalMove(_startPosition, _tweenTime)
            .SetDelay(_delayTime)
            .SetEase(_easeType)
            .SetLink(gameObject)
            .OnComplete(FirstMove);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CheckPlayer(collision.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CheckPlayer(collision.gameObject);
        }

        private void CheckPlayer(GameObject obj)
        {
            if (obj.CompareTag("Player"))
            {
                obj.transform.parent = transform;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            ExitCheck(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            ExitCheck(collision.gameObject);
        }

        private void ExitCheck(GameObject obj)
        {
            if (obj.CompareTag("Player"))
            {
                obj.transform.parent = null;
            }
        }
    }
}
