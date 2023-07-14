using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    // トレイルするか
    private bool _isTrail;

    [SerializeField, Header("トレイルさせる時間")]
    private float _trailTime;

    [SerializeField]
    private TrailRenderer _trailRenderer;

    [SerializeField]
    private GameObject _particle;

    private Vector2 _startPos;
    private Vector2 _endPos;


    private void Update()
    {
        Trailing();

        //if(Input.GetKeyDown(KeyCode.Return))
        //{
        //    StartTrailing(new Vector2(-2,-2),new Vector2(2,1));
        //}
    }


    /// <summary>
    /// 座標移動を開始してトレイルをつける
    /// </summary>
    /// <param name="startPos">始める座標</param>
    /// <param name="endPos">終了の座標</param>
    public void StartTrailing(Vector2 startPos, Vector2 endPos)
    {
        _isTrail = false;
        _trailRenderer.enabled = false;
        transform.position = startPos;
        _startPos = startPos;
        _endPos = endPos;
        _trailRenderer.enabled = true;
        _isTrail = true;

    }
    private void Trailing()
    {
        if (!_isTrail) { return; }

        Vector2 nowPos = transform.position;

        float startPosToEndPosLength = (Vector2.Distance(_startPos, _endPos / 2));
        float nowPosToEndPosLength = Vector2.Distance(nowPos, _endPos / 2);


        if ((startPosToEndPosLength - nowPosToEndPosLength) < 0)
        {
            _isTrail = false;
            Instantiate(_particle, transform.position, Quaternion.identity);
            return;
        }
        float speed = startPosToEndPosLength / (_trailTime * 120);
        Vector3 nextPos = (_endPos - _startPos).normalized * speed;

        transform.position += nextPos;

    }

}
