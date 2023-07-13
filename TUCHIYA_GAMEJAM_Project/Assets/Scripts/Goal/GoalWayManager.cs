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

    // Update is called once per frame
    void Update()
    {
        player1Progress = (player1.transform.position.y - minPos) / stageLange;
        player2Progress = (player2.transform.position.y - minPos) / stageLange;
        //Debug.Log("êiíªäÑçá"+player1Progress);
        //Debug.Log("UIÇÃí∑Ç≥"+ UILange);
        player1Logo.transform.position =
            new Vector3(player1Logo.transform.position.x, UILange * player1Progress + minUIPos, player1Logo.transform.position.z);
        player2Logo.transform.position =
        new Vector3(player2Logo.transform.position.x, UILange * player2Progress + minUIPos, player1Logo.transform.position.z);

    }
}
