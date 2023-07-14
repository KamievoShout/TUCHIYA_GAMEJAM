using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Vector3 RespawnPos = Vector3.zero;
    public GameObject[] Respawnobj;
    public float height;

    public static RespawnController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameObject.FindGameObjectsWithTag("Respawn");
    }
}
