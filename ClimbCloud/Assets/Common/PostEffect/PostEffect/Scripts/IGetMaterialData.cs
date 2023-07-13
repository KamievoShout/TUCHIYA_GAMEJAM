using UnityEngine;

namespace Utility.PostEffect
{
    public interface IGetMaterialData
    {
        void SetShader(PostEffectType type, ref Material mat);
    }
}
