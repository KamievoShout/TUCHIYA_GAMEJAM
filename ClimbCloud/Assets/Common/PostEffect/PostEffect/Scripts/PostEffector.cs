using UnityEngine;
using DG.Tweening;
using System;
using Utility;

namespace Utility.PostEffect
{
    public class PostEffector
    {
        private IGetMaterialData materialDB;

        public PostEffector()
        {
            materialDB = Locator<IGetMaterialData>.Resolve();
        }

        public void Fade(PostEffectType postEffectType, float time, Color color, FadeType fadeType, Ease ease = Ease.Linear)
        {
            Material mat = null;
            materialDB.SetShader(postEffectType, ref mat);

            Action<FadeType, Material> startAction = GetStartAction(postEffectType);
            Action<FadeType, Material, float> updateAction = GetUpdateAction(postEffectType);
            Action<FadeType, Material> endAction = GetEndAction(postEffectType);

            mat.SetColor("_Color", color);
            int fadeId = Shader.PropertyToID("_Fade");
            int startValue = 1;
            int endValue = 0;
            switch (fadeType)
            {
                case FadeType.In:
                    break;
                case FadeType.Out:
                    startValue = 0;
                    endValue = 1;
                    break;
            }

            DOVirtual.Float(startValue, endValue, time, value =>
            {
                mat.SetFloat(fadeId, value);
                updateAction?.Invoke(fadeType, mat, value);
            }).OnStart(() =>
            {
                startAction?.Invoke(fadeType, mat);

            }).SetEase(ease).onComplete += () =>
            {
                endAction?.Invoke(fadeType, mat);
            };

        }

        private Action<FadeType, Material> GetStartAction(PostEffectType postEffectType)
        {
            switch (postEffectType)
            {
                default:
                    return null;
            }
        }

        private Action<FadeType, Material, float> GetUpdateAction(PostEffectType postEffectType)
        {
            switch (postEffectType)
            {
                case PostEffectType.PressureFade:
                    return (fadeType, mat, fade) =>
                    {
                        mat.SetFloat("_Zoom", fade);
                        mat.SetFloat("_PressureStrength", fade);
                    };
                default:
                    return null;
            }
        }

        private Action<FadeType, Material> GetEndAction(PostEffectType postEffectType)
        {
            switch (postEffectType)
            {
                default:
                    return null;
            }
        }

        public enum FadeType
        {
            In,
            Out,
        }
    }
}