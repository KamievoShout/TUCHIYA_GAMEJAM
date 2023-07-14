using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StageObject
{
    public class AfterImage : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] rends;
        [SerializeField] private AfterImageElement prefab;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float lifeTime;
        [SerializeField] private float interval;

        private float nowTime = 0;

        private void Update()
        {
            nowTime += Time.deltaTime;
            if(nowTime > interval)
            {
                for (int i = 0; i < rends.Length; i++)
                {
                    AfterImageElement element = Instantiate(prefab, rends[i].transform.position + offset, rends[i].transform.rotation);
                    element.transform.localScale = rends[i].transform.lossyScale;
                    element.Initalize(lifeTime, rends[i].sprite);
                }
                nowTime = 0;
            }
        }
    }
}