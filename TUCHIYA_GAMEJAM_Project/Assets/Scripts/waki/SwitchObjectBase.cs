using UnityEngine;

public class SwitchObjectBase : MonoBehaviour
{
    public virtual void SwitchPushed()
    {
        Debug.Log("switch�N��");
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // �v���C���[�̃_���[�W�̓z�o����܂őҋ@�Ȃ�
    //    if (collision.GetComponent<PlayerController>() != null)
    //    {
    //        SwitchPushed();
    //    }
    //}


    
}
