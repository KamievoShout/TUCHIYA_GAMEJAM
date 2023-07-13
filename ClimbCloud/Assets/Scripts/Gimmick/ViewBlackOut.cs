using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ViewBlackOut : Gimmick
{
    [SerializeField, Header("��ʂ��Â����銄���̍ő�l"), Range(0, 1f)]
    private float _maxImgageAlpha;

    [SerializeField, Header("��ʂ��Â������銄��(�Â�������X�s�[�h)"), Range(0, 10f)]
    private float _addAlpha;

    // ��ʂ��Â�����摜
    [SerializeField,Header("�Â�������摜")]
    private Image _blackOutImg;

    // ��ʂ��Â������邩
    private bool _isBlackOut;

    private void Start()
    {
        _isBlackOut = false;
        Initialized();
    }

    private void Update()
    {
        BlackOut();
    }

    /// <summary>
    /// ��ʂ��Â�������
    /// </summary>
    public void StartBlackOut()
    {
        _isBlackOut = true;
    }


    /// <summary>
    /// �Â�������̂���߂�
    /// </summary>
    public void QuitBlackOut()
    {
        Initialized();
    }

    /// <summary>
    /// ��ʂ��Â������鏈��
    /// </summary>
    private void BlackOut()
    {
        // ��ʂ��Â��������Ȃ��Ƃ��͂��Ȃ�
        if (!_isBlackOut) { return; }

        // ��ʂ��Â�����摜�������Ă��Ȃ�������A�G���[���͂�
        if (_blackOutImg == null)
        {
            Debug.LogError("�Â�����摜�������Ă��Ȃ�");
        }

        // �w�肵���ő�l��胿�l���傫���Ȃ����玫�߂�
        if (_blackOutImg.color.a >= _maxImgageAlpha)
        {
            _isBlackOut = false;
            return;
        }

        // ��ʂ��Â�������
        _blackOutImg.color += new Color(0, 0, 0, _addAlpha / 100);

    }

    /// <summary>
    /// �摜��������������
    /// </summary>
    private void Initialized()
    {
        // ��ʂ��Â�����摜�������Ă��Ȃ�������A�G���[���͂�
        if (_blackOutImg == null)
        {
            Debug.LogError("�Â�����摜�������Ă��Ȃ�");
        }
        _blackOutImg.color = new Color(0, 0, 0, 0);
    }

}
