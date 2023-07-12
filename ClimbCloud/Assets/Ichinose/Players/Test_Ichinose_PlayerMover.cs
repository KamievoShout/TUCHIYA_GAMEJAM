using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Test_Ichinose_PlayerMover : MonoBehaviour
    {
        [SerializeField, Min(0)]
        private float _moveSpeed = 10.0f;

        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");

            if (x != 0)
            {
                _rb.velocity = new Vector2(x * _moveSpeed, _rb.velocity.y) ;
            }
        }
    }
}
