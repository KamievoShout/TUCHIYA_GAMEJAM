using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem[] effects;

    [SerializeField]
    private CameraController cameraController;

    private void Awake()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].gameObject.transform.position = transform.position;
        }
    }
    public void Goal()
    {
        cameraController.GoalCamera(transform.position);
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Play();
        }
    }
}
