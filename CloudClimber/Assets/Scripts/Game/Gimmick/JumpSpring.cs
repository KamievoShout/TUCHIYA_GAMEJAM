using UnityEngine;

public class JumpSpring : MonoBehaviour
{
    [SerializeField, PropertyName("�o�l�̃W�����v��")]
    private float SpringPower = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!TryGetComponent(out Player p)) return;

        //Player�R���|�[�l���g�������Ă���
        //Player��SpringPower���̃W�����v�͂�n��
        if (collision.TryGetComponent(out Player p))
        {
            p.Jump(SpringPower);
        }
    }
}
