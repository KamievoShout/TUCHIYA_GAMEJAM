using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStan : MonoBehaviour
{
    PlayerController playerController;
    Animator animator;
    [SerializeField]
    float stanTime;

    bool flg;

    private void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        animator = gameObject.GetComponentInChildren<Animator>();
        flg = false;
    }
    public void Stan()
    {
        if(!flg)
            StartCoroutine("stanMotion");
    }
    IEnumerator stanMotion()
    {
        flg = true;
        playerController.isControl = false;
        animator.Play("PL_stanAnimation");
        yield return new WaitForSeconds(stanTime);
        playerController.isControl = true;
        animator.Play("PL_defaultAnimation");
        flg = false;
    }
}
