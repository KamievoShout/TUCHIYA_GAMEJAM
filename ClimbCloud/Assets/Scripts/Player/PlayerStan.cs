using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStan : MonoBehaviour
{
    PlayerController playerController;
    Animator animator;
    [SerializeField]
    float stanTime;

    private void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        animator = gameObject.GetComponentInChildren<Animator>();

    }
    public void Stan()
    {
        StartCoroutine("stanMotion");
    }
    IEnumerator stanMotion()
    {
        playerController.isControl = false;
        animator.Play("PL_stanAnimation");
        yield return new WaitForSeconds(stanTime);
        playerController.isControl = true;
        animator.Play("PL_defaultAnimation");
    }
}
