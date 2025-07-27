using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    GameEvent onSelect;

    [SerializeField]
    GameEvent<Vector2> onMove;

    [SerializeField]
    GameEvent onQuit;

    [SerializeField]
    GameEvent onReset;

    [SerializeField]
    GameEvent onScreenshot;

    [SerializeField]
    GameEvent onNext;

    [SerializeField]
    GameEvent onPrevious;

    public void HandleMoveAction(InputAction.CallbackContext context)
    {
        var dir = context.ReadValue<Vector2>();
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            dir.y = 0;
            dir.x = Mathf.Sign(dir.x);
        }
        else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
        {
            dir.x = 0;
            dir.y = Mathf.Sign(dir.y);
        }
        else
        {
            dir.x = 0;
            dir.y = 0;
        }
        onMove.Invoke(dir);
    }

    public void HandleQuitAction(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && context.started)
        {
            onQuit.Invoke();
        }
    }

    public void HandleScreenshotAction(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && context.started)
        {
            onScreenshot.Invoke();
        }
    }

    public void HandleResetAction(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && context.started)
        {
            onReset.Invoke();
        }
    }

    public void HandleSelectAction(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && context.started)
        {
            onSelect.Invoke();
        }
    }

    public void HandleNextAction(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && context.started)
        {
            onNext.Invoke();
        }
    }

    public void HandlePreviousAction(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && context.started)
        {
            onPrevious.Invoke();
        }
    }
}
