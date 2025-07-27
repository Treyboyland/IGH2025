using UnityEngine;

public class InvokeEventOnStart : MonoBehaviour
{
    [SerializeField]
    GameEvent eventToInvoke;

    void Start()
    {
        eventToInvoke.Invoke();
    }
}
