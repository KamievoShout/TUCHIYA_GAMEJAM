using UnityEngine;

namespace Cameras
{
    public class CameraController : MonoBehaviour
    {
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

        private void LateUpdate()
        {
            Vector3 playerPos = _player.transform.position;

            transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        }
    }
}