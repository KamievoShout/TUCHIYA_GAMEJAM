using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] SwitchObjectBase switchObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            switchObject.SwitchPushed();
        }
    }

}
