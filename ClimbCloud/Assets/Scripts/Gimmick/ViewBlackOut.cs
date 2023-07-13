using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ViewBlackOut : Gimmick
{
    [SerializeField, Header("画面を暗くする割合の最大値"), Range(0, 1f)]
    private float _maxImgageAlpha;

    [SerializeField, Header("画面を暗くさせる割合(暗くさせるスピード)"), Range(0, 10f)]
    private float _addAlpha;

    // 画面を暗くする画像
    [SerializeField,Header("暗くさせる画像")]
    private Image _blackOutImg;

    // 画面を暗くさせるか
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
    /// 画面を暗くさせる
    /// </summary>
    public void StartBlackOut()
    {
        _isBlackOut = true;
    }


    /// <summary>
    /// 暗くさせるのをやめる
    /// </summary>
    public void QuitBlackOut()
    {
        Initialized();
    }

    /// <summary>
    /// 画面を暗くさせる処理
    /// </summary>
    private void BlackOut()
    {
        // 画面を暗くしたくないときはしない
        if (!_isBlackOut) { return; }

        // 画面を暗くする画像を持っていなかったら、エラーをはく
        if (_blackOutImg == null)
        {
            Debug.LogError("暗くする画像を持っていない");
        }

        // 指定した最大値よりα値が大きくなったら辞める
        if (_blackOutImg.color.a >= _maxImgageAlpha)
        {
            _isBlackOut = false;
            return;
        }

        // 画面を暗くさせる
        _blackOutImg.color += new Color(0, 0, 0, _addAlpha / 100);

    }

    /// <summary>
    /// 画像を初期化させる
    /// </summary>
    private void Initialized()
    {
        // 画面を暗くする画像を持っていなかったら、エラーをはく
        if (_blackOutImg == null)
        {
            Debug.LogError("暗くする画像を持っていない");
        }
        _blackOutImg.color = new Color(0, 0, 0, 0);
    }

}
