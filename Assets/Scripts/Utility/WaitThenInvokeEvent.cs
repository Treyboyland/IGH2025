using System.Collections;
using UnityEngine;

public class WaitThenInvokeEvent : MonoBehaviour
{
    [SerializeField]
    float secondsToWait;

    [SerializeField]
    GameEvent eventToFire;

    bool isWaiting;

    public void StartEventFiring()
    {
        if (!isWaiting)
        {
            StartCoroutine(WaitThenInvoke());
        }
    }

    public void StopEvent()
    {
        StopAllCoroutines();
        isWaiting = false;
    }

    IEnumerator WaitThenInvoke()
    {
        isWaiting = true;
        yield return new WaitForSeconds(secondsToWait);
        eventToFire.Invoke();
        isWaiting = false;
    }
}
