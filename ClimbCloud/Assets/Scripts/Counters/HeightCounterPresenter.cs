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

            // �v���C���[��Y���W���Ď�
            player.transform.ObserveEveryValueChanged(_ => player.transform.position.y)
                .DistinctUntilChanged()
                .Subscribe(posY =>
                {
                    _model.SetCounter((int)posY);
                })
                .AddTo(this);

            // ���݂̍������ς������view�ɒʒm
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
