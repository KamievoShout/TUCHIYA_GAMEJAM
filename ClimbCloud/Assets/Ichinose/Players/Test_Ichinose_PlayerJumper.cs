using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Test_Ichinose_PlayerJumper : MonoBehaviour
    {
        private Rigidbody2D _rb;

        [SerializeField, Min(0)]
        private float _jumpPower = 5;

        [SerializeField]
        private AnimationCurve _animCurve;

        [SerializeField, Min(0)]
        private float _maxChargeTime = 3f;

        private float _chargeTime;

        private bool _isJumping = false;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isJumping = true;
            }


            if (_isJumping)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Jump();

                    _isJumping = false;
                    _chargeTime = 0;
                }

                else if (Input.GetKey(KeyCode.Space))
                {
                    _chargeTime += Time.deltaTime;
                }
            }
        }

        private void Jump()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0);

            float t = _chargeTime / _maxChargeTime;
            float power = _jumpPower * _animCurve.Evaluate(t);

            _rb.AddForce(power * Vector2.up, ForceMode2D.Impulse);
        }
    }
}