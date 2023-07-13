using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float skipDistance = 150;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime);

        Debug.Log(player.transform.position.y - transform.position.y);
        if (player.transform.position.y - transform.position.y > skipDistance)
        {
            transform.position = new Vector3(0, player.transform.position.y - skipDistance);
        }
    }
}
