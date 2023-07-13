using UnityEngine;

namespace Utility.PostEffect
{
    public interface IPostEffectCamera
    {
        void Move(Vector2 pos);
        Vector2 GetPosition();

        void Rotate(float z);
        float GetRotation();

        void SetOrthograhicSize(float size);
        float GetOrthograhicSize();

        void Shake(Vector2 power, float time, float interval = 0.01f);

        Vector2 ScreenToWorldPoint(Vector3 worldPoint, Camera.MonoOrStereoscopicEye eye);
        Vector2 WorldToScreenPoint(Vector3 screenPoint, Camera.MonoOrStereoscopicEye eye);
        Vector2 ViewportToScreenPoint(Vector3 viewportPoint);
        Vector2 ScreenToViewportPoint(Vector3 screenPoint);
        Vector2 ViewportToWorldPoint(Vector3 viewportPoint);
        Vector2 WorldToViewportPoint(Vector3 worldPoint);

    }
}