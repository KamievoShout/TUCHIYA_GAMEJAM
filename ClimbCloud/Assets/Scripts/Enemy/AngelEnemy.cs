using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Utility.Audio;

public class AngelEnemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Arrow arrowPrefab;
    [SerializeField] private float shotInterval = 1.5f;
    [SerializeField] private float noticeDistance = 150;

    private Transform player;
    private float nowTime = 0;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Mathf.Abs(Mathf.Abs(player.position.y) - Mathf.Abs(transform.position.y));
        if (distance < noticeDistance)
        {
            nowTime += Time.deltaTime;
            if(nowTime > shotInterval)
            {
                nowTime = 0;
                animator.SetTrigger("Shot");
            }
        }

        if(transform.position.x > player.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Shot()
    {
        Locator<IPlayAudio>.Resolve().PlaySE("ShotArrow");
        Arrow arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        Vector2 dir = ((Vector2)player.position - (Vector2)transform.transform.position).normalized;
        arrow.SetDir(dir);
    }
}
