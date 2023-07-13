using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utility.PostEffect
{
    public class PostEffectMaterialDB : MonoBehaviour, IGetMaterialData
    {
        [SerializeField] private PostEffectShaderData[] datas = null;
        [SerializeField] RawImage rawImage = null;

        void IGetMaterialData.SetShader(PostEffectType type, ref Material mat)
        {
            foreach (PostEffectShaderData data in datas)
            {
                if (type == data.Type)
                {
                    rawImage.material.shader = data.Shader;
                    mat = rawImage.material;
                    return;
                }
            }
        }
    }

    [System.Serializable]
    public class PostEffectShaderData
    {
        [SerializeField] PostEffectType type = PostEffectType.SimpleFade;
        [SerializeField] Shader shader = null;

        public PostEffectType Type => type;
        public Shader Shader => shader;
    }
}
