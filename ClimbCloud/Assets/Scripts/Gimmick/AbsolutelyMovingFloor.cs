using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsolutelyMovingFloor : MonoBehaviour, Gimmick
{
    List<GameObject> _floor = new List<GameObject>();
    private void Update()
    {

    }


    private void MovingFloor()
    {

    }


    //���̃I�u�W�F�N�g��GameView�݂̂ŕ`�悳��Ă��邩����p�ɁA
    void OnWillRenderObject()
    {

#if UNITY_EDITOR

        // Debug.LogError("isVisible:::::camera:" + Camera.current.name);

        if (Camera.current.name != "SceneCamera" && Camera.current.name != "Preview Camera")
        {
        }
#endif
    }

}
