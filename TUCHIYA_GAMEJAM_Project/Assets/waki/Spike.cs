using UnityEngine;

public class Spike : SwitchObjectBase
{
    [SerializeField]
    private int spikeDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �v���C���[�̃_���[�W�̓z�o����܂őҋ@�Ȃ�
        if(collision.GetComponent<PlayerController>() != null)
        {
            Debug.Log("�_���[�W�_���[�W");
        }
    }


}
