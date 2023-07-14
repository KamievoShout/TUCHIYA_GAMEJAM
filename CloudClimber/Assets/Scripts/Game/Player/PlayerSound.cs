using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace PlayerInternal
{
    public class PlayerSound : MonoBehaviour
    {
        [SerializeField]
        AudioSource source;

        [SerializeField]
        float audioOffset = 0.05f;

        void Start()
        {
            GetComponent<PlayerMover>()
                .Jumping
                .Subscribe(_ =>
                {
                    source.Play();
                    source.time = audioOffset;
                })
                .AddTo(this);
        }
    }
}