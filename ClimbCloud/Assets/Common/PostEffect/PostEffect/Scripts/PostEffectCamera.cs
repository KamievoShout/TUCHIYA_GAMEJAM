using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utility.PostEffect
{
    public class PostEffectCamera : MonoBehaviour, IPostEffectCamera
    {
		[SerializeField] Camera postEffectCamera = null;
        [SerializeField] RenderTexture renderTexture = null;

		private Coroutine shakeCoroutine;

        private void Awake()
        {
			renderTexture.Release();

			renderTexture.width = Screen.width;
            renderTexture.height = Screen.height;

			renderTexture.Create();
		}

		Vector2 IPostEffectCamera.GetPosition()
		{
			return transform.position;
		}

		float IPostEffectCamera.GetRotation()
		{
			return transform.eulerAngles.z;
		}

		void IPostEffectCamera.Move(Vector2 pos)
		{
			transform.position = new Vector3(pos.x, pos.y, transform.position.z);
		}

		void IPostEffectCamera.Rotate(float z)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, z);
		}

		void IPostEffectCamera.SetOrthograhicSize(float size)
		{
			postEffectCamera.orthographicSize = size;
		}

		float IPostEffectCamera.GetOrthograhicSize()
		{
			return postEffectCamera.orthographicSize;
		}

		public void Shake(Vector2 power, float time, float interval = 0.01f)
		{
			if (shakeCoroutine != null) StopCoroutine(shakeCoroutine);
			shakeCoroutine = StartCoroutine(ShakeCoroutine(power, time, interval));
		}

		private IEnumerator ShakeCoroutine(Vector2 power, float time, float interval)
		{
			float nowTime = 0;
			float beforeTime = 0;
			Vector2 offset = Vector2.zero;
			while(nowTime < time)
			{
				nowTime += Time.deltaTime;
				if (nowTime - beforeTime > interval)
				{
					transform.position -= (Vector3)offset;
					beforeTime = nowTime;
					offset.x = Random.Range(-power.x, power.x);
					offset.y = Random.Range(-power.y, power.y);
					transform.position += (Vector3)offset;
				}
				yield return null;
			}
			shakeCoroutine = null;
		}

		Vector2 IPostEffectCamera.ScreenToWorldPoint(Vector3 worldPoint, Camera.MonoOrStereoscopicEye eye)
        {
			return postEffectCamera.ScreenToWorldPoint(worldPoint, eye);
		}

		Vector2 IPostEffectCamera.WorldToScreenPoint(Vector3 screenPoint, Camera.MonoOrStereoscopicEye eye)
		{
			return postEffectCamera.WorldToScreenPoint(screenPoint, eye);
		}

		Vector2 IPostEffectCamera.ViewportToScreenPoint(Vector3 viewportPoint)
		{
			return postEffectCamera.ViewportToScreenPoint(viewportPoint);
		}

		Vector2 IPostEffectCamera.ScreenToViewportPoint(Vector3 screenPoint)
		{
			return postEffectCamera.ScreenToViewportPoint(screenPoint);
		}

		Vector2 IPostEffectCamera.ViewportToWorldPoint(Vector3 viewportPoint)
		{
			return postEffectCamera.ViewportToWorldPoint(viewportPoint);
		}

		Vector2 IPostEffectCamera.WorldToViewportPoint(Vector3 worldPoint)
		{
			return postEffectCamera.WorldToViewportPoint(worldPoint);
		}
	}
}
