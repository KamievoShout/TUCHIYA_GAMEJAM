using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Sprite[] images;  // �؂�ւ���摜�̔z��
    public Image imageComponent;  // �摜��\������UI Image�R���|�[�l���g

    private int currentIndex = 0;  // ���݂̉摜�C���f�b�N�X

    private void Start()
    {
        // �ŏ��̉摜��\������
        if (images.Length > 0)
        {
            imageComponent.sprite = images[currentIndex];
        }
    }

    public void SwitchImage(bool next)
    {
        // �摜��؂�ւ���
        switch (next)
        {
            case true:  // ���̉摜
                currentIndex = (currentIndex + 1) % images.Length;
                break;
            case false:  // �O�̉摜
                currentIndex = (currentIndex - 1 + images.Length) % images.Length;
                break;
        }
        imageComponent.sprite = images[currentIndex];
    }
}
