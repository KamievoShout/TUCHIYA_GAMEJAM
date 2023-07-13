using UnityEngine;

namespace Cameras
{
    public class CameraController : MonoBehaviour
    {
        private GameObject _player;

        private Vector3 _offset;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");

            _offset = transform.position;
        }

        private void LateUpdate()
        {
            Vector3 playerPos = _player.transform.position;

            transform.position = new Vector3(transform.position.x, playerPos.y + _offset.y, transform.position.z);
        }
    }
}