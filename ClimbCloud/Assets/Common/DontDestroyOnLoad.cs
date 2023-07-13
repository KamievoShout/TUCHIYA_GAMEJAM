using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
