using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalWayManager : MonoBehaviour
{
    [SerializeField] GameObject player1Logo;
    [SerializeField] GameObject player2Logo;
    [SerializeField] float minUIPos;
    [SerializeField] float maxUIPos;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] float minPos;
    [SerializeField] float maxPos;

    float stageLange;
    float UILange;
    float player1Progress;
    float player2Progress;
    // Start is called before the first frame update
    void Start()
    {
        stageLange = maxPos - minPos;
        UILange = maxUIPos - minUIPos;
    }
    void Update()
    {
        player1Progress = (player1.transform.position.y - minPos) / stageLange;
        player2Progress = (player2.transform.position.y - minPos) / stageLange;

        player1Logo.transform.localPosition =
            new Vector3(player1Logo.transform.localPosition.x, UILange * player1Progress + minUIPos, player1Logo.transform.localPosition.z);
        player2Logo.transform.localPosition =
        new Vector3(player2Logo.transform.localPosition.x, UILange * player2Progress + minUIPos, player1Logo.transform.localPosition.z);

    }
}
