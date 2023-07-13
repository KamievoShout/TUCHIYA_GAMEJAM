using UnityEngine;

public class JumpSpring : MonoBehaviour
{
    [SerializeField, PropertyName("バネのジャンプ力")]
    private float SpringPower = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!TryGetComponent(out Player p)) return;

        //Playerコンポーネントを持ってたら
        //PlayerにSpringPower分のジャンプ力を渡す
        if (collision.TryGetComponent(out Player p))
        {
            p.Jump(SpringPower);
        }
    }
}
