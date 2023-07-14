using UnityEngine;

public class SwitchObjectBase : MonoBehaviour
{
    public virtual void SwitchPushed()
    {
        Debug.Log("switch起動");
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // プレイヤーのダメージの奴出来るまで待機なう
    //    if (collision.GetComponent<PlayerController>() != null)
    //    {
    //        SwitchPushed();
    //    }
    //}


    
}
