using UnityEngine;
using UniRx;
using System.Collections.Generic;

namespace createMaps
{
    public class CreateMap : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _clouds;

        private List<GameObject> _cloudsList;

        private Transform _playerTransform;

        // 無効化した雲の数
        private int _disableCloudCount = 0;

        // 最高到達点
        private float _tidemark = 0;

        private float _nextGeneratePositionY = 0;

        private void Start()
        {
            _cloudsList = new List<GameObject>();

            GameObject player = GameObject.FindWithTag("Player");

            _playerTransform = player.transform;

            Initialize();
        }

        private void Initialize()
        {
            // プレイヤーのポジションが変化したら処理を通す
            _playerTransform.ObserveEveryValueChanged(_ => _playerTransform.position.y)
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    InstantiateCloud(x);

                    DisableCloud();
                })
                .AddTo(this);
        }

        // 雲非表示
        private void DisableCloud()
        {
            if (_cloudsList == null || _cloudsList.Count < 0) { return; }

            float nearCloudPosY = _cloudsList[_disableCloudCount].gameObject.transform.position.y;

            if (_playerTransform.position.y > nearCloudPosY + 1080)
            {
                _cloudsList[_disableCloudCount].SetActive(false);

                _disableCloudCount++;
            }
        }

        // 雲生成
        private void InstantiateCloud(float currentPlayerPositionY)
        {
            if (_tidemark < currentPlayerPositionY)
            {
                if (_tidemark > _nextGeneratePositionY - 270)
                {
                    int index = UnityEngine.Random.Range(0, _clouds.Length);

                    GameObject cloud = Instantiate(_clouds[index], new Vector3(0, _nextGeneratePositionY, 0), Quaternion.identity);

                    cloud.transform.parent = transform;

                    _cloudsList.Add(cloud);

                    _nextGeneratePositionY += 360.0f;
                }

                _tidemark = currentPlayerPositionY;
            }
        }
    }
}