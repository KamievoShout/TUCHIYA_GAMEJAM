using UnityEngine;
using Utility;
using Utility.PostEffect;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform moveObject;
    [SerializeField] private Transform followTarget;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float followSpeed = 1;
    [SerializeField] private bool isX = true;
    [SerializeField] private bool isY = true;
    [SerializeField] private bool isCamera = true;

	private void Update()
    {
        Vector2 pos_1 = new Vector2();
        if(isCamera)
        {
            if (isX) pos_1.x = Locator<IPostEffectCamera>.Resolve().GetPosition().x;
            if (isY) pos_1.y = Locator<IPostEffectCamera>.Resolve().GetPosition().y;
        }
        else
        {
            if (isX) pos_1.x = moveObject.position.x;
            if (isY) pos_1.y = moveObject.position.y;
        }

        Vector2 pos_2 = new Vector2();
        if (isX) pos_2.x = followTarget.position.x;
        if (isY) pos_2.y = followTarget.position.y;


        Vector2 pos = Vector2.Lerp(pos_1, pos_2 + offset, Time.deltaTime * followSpeed);
        if (isCamera)
        {
            Locator<IPostEffectCamera>.Resolve().Move(new Vector3(pos.x, pos.y, moveObject.position.z));
        }
        else
        {
            moveObject.position = new Vector3(pos.x, pos.y, moveObject.position.z);
        }
    }
}
