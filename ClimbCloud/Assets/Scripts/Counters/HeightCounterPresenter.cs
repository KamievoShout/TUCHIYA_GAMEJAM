using UnityEngine;
using UniRx;

namespace HeightCounters
{
    public class HeightCounterPresenter : MonoBehaviour
    {
        [SerializeField]
        private HeightCounterModel _model;

        [SerializeField]
        private HeightCounterView _view;

        private void Start()
        {
            GameObject player = GameObject.FindWithTag("Player");

            // プレイヤーのY座標を監視
            player.transform.ObserveEveryValueChanged(_ => player.transform.position.y)
                .DistinctUntilChanged()
                .Subscribe(posY =>
                {
                    _model.SetCounter(posY);
                })
                .AddTo(this);

            // 最高到達点が変わったらviewに通知
            _model.ObserveEveryValueChanged(_ => _model.Tidemark)
                .DistinctUntilChanged()
                .Subscribe(tidemark =>
                {
                    _view.SetCounterView(tidemark);
                })
                .AddTo(this);
        }
    }
}
