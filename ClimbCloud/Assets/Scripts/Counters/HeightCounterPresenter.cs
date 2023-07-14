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
                    _model.SetCounter((int)posY);
                })
                .AddTo(this);

            // 現在の高さが変わったらviewに通知
            _model.ObserveEveryValueChanged(_ => _model.CurrentHeight)
                .DistinctUntilChanged()
                .Subscribe(currentHeight =>
                {
                    _view.SetCounterView(currentHeight);
                })
                .AddTo(this);
        }
    }
}
