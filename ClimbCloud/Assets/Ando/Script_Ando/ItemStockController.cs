using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStockController : MonoBehaviour
{
    public bool rocketLaunch = false; 

    string itemName;

    //��������UI�֌W
    public Sprite[] images;  // �؂�ւ���摜�̔z��
    public Image imageComponent;  // �摜��\������UI Image�R���|�[�l���g
    //private int currentIndex = 0;  // ���݂̉摜�C���f�b�N�X
    private void Start()
    {
       imageComponent.sprite = images[0];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �A�C�e���Ƃ̏Փ˂����o
        GameObject item = collision.gameObject;
        // �A�C�e���̃^�O��ǂݎ��
        string itemTag = item.tag;

        // �^�O�Ɋ�Â��ď������s��
        switch (itemTag)
        {
            case "zero":
                imageComponent.sprite = images[0];
                Debug.Log("�����Ȃ�");
                break;
            case "Rocket":
                imageComponent.sprite = images[1];
                itemName = "���P�b�g";
                // �ǉ��̏�����ǋL
                break;
            case "Umbrella":
                imageComponent.sprite = images[2];
                itemName = "�P";
                // �ǉ��̏�����ǋL
                break;
        }



        if (collision.CompareTag("Rocket") || collision.CompareTag("Umbrella"))
        {
            // �A�C�e���I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);
        }
    }
    public void Update()
    {
        //imageComponent.sprite = images[currentIndex];
        if (Input.GetKeyDown(KeyCode.Z) && itemName == "���P�b�g")
        {

            SoundEffectManager.instance.PlaySoundEffect(5);
            rocketLaunch = true;
            itemName = "zero";
            imageComponent.sprite = images[0];
        }
        Debug.Log(itemName + "���g���܂�!");
    }
}
