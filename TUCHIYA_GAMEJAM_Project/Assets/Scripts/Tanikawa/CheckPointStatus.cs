using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckPoint
{
    public class CheckPointStatus:MonoBehaviour
    {
        [SerializeField]
        private Vector3 restartPosition = Vector3.zero;


        public void CheckPosition(Vector3 checkPosition)
        {
            restartPosition = checkPosition;
        }

        public Vector3 Restart()
        {
            return restartPosition;
        }
    }
}
