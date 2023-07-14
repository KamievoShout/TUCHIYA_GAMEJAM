using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem[] effects;

    [SerializeField]
    private CameraController[] cameraControllers;

    private void Awake()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].gameObject.transform.position = transform.position;
        }
    }
    public void Goal()
    {
        cameraControllers[0].GoalCamera(transform.position);
        cameraControllers[1].GoalCamera(transform.position);
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Play();
        }
    }
}
