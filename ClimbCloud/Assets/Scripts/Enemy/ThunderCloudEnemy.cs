using UnityEngine;

public class ThunderCloudEnemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveRangeMin = -128;
    [SerializeField] private float moveRangeMax = 128;
    [SerializeField] private int firstMoveDir = 1;
    [SerializeField] private float moveDuration = 3f;
    [SerializeField] private float shotDuration = 1f;

    private float moveTime;
    private int moveDir;
    private float shotTime;
    private bool isShot = false;

    private void Start()
    {
        moveDir = firstMoveDir;
    }

    private void Update()
    {
        if (!isShot)
        {
            if (moveTime < moveDuration)
            {
                moveTime += Time.deltaTime;
                transform.position += new Vector3(moveSpeed * Time.deltaTime * moveDir, 0, 0);

                if (transform.position.x >= moveRangeMax)
                {
                    moveDir = -1;
                }
                else
                if (transform.position.x <= moveRangeMin)
                {
                    moveDir = 1;
                }
            }
            else
            {
                moveTime = 0;
                isShot = true;
                animator.SetTrigger("Shot");
            }
        }
        else
        {
            if (shotTime < shotDuration)
            {
                shotTime += Time.deltaTime;
            }
            else
            {
                shotTime = 0;
                isShot = false;
                animator.SetTrigger("Move");
                Debug.Log("O");
            }
        }
    }
}
