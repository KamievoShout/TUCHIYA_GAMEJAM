using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ViewBlackOut : MonoBehaviour
{
    [SerializeField, Header("��ʂ��Â����銄���̍ő�l"), Range(0, 1f)]
    private float _maxImgageAlpha;

    [SerializeField, Header("��ʂ��Â������銄��"), Range(0, 1f)]
    private float _addAlpha;

    // ��ʂ��Â�����摜
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _isBlackOut = true;
        }

        BlackOut();
    }

    /// <summary>
    /// ��ʂ��Â�������
    /// </summary>
    private void BlackOut()
    {
        // ��ʂ��Â��������Ȃ��Ƃ��͂��Ȃ�
        if (!_isBlackOut) { return; }

        // ��ʂ��Â�����摜�������Ă��Ȃ�������A�擾����
        if (_blackOutImg == null)
        {
            _blackOutImg = GameObject.Find("BlackOutImg").GetComponent<Image>();
        }

        // �w�肵���ő�l��胿�l���傫���Ȃ����玫�߂�
        if (_blackOutImg.color.a >= _maxImgageAlpha)
        {
            _isBlackOut = false;
            return;
        }

        // ��ʂ��Â�������
        _blackOutImg.color += new Color(0, 0, 0, _addAlpha/100);

    }

    /// <summary>
    /// �摜��������������
    /// </summary>
    private void Initialized()
    {
        _blackOutImg = GameObject.Find("BlackOutImg").GetComponent<Image>();
        _blackOutImg.color = new Color(0, 0, 0, 0);
    }

}
