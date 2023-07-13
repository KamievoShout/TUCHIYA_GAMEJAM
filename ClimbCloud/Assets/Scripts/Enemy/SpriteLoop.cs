using UnityEngine;

public class SpriteLoop : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private Sprites[] spriteLists;
    [SerializeField] private float interval = 0.05f;

    private float nowTime;
    private int spriteIdx;
    private int spriteListIdx;

    private void Start()
    {
        spriteListIdx = Random.Range(0, spriteLists.Length);
    }

    private void Update()
    {
        nowTime += Time.deltaTime;
        if(nowTime > interval)
        {
            nowTime = 0;
            spriteIdx++;
            if (spriteIdx >= spriteLists[spriteListIdx].sprites.Length)
            {
                spriteIdx = 0;
            }
            rend.sprite = spriteLists[spriteListIdx].sprites[spriteIdx];
        }
    }

    [System.Serializable]
    public class Sprites
    {
        public Sprite[] sprites;
    }
}
