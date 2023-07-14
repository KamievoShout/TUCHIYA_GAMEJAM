using Player;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] SwitchObjectBase switchObject;
    [SerializeField] Sprite onSwitchSpr;
    [SerializeField] Sprite offSwitchSpr;

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
        if (collision.GetComponent<PlayerCore>() != null)
        {
            GetComponent<SpriteRenderer>().sprite = offSwitchSpr;
            switchObject.SwitchPushed();
        }
    }

}
