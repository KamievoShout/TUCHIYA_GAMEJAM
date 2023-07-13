using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float jumpPower = 1;

    private int dir;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            dir = -1;
            rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);
        }
        else
        if (Input.GetKey(KeyCode.D))
        {
            dir = 1;
            rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y); 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(dir, 1).normalized * jumpPower, ForceMode2D.Impulse);
        }
    }
}
