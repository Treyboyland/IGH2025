using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    MovementDirectionSO currentDirection;

    [SerializeField]
    Player player;

    [SerializeField]
    float movementDelay;

    float elapsed;

    MovementDirectionSO previousDirection;

    [SerializeField]
    MovementDirectionSO up, down, left, right, none;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentDirection == previousDirection)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= movementDelay)
            {
                elapsed = 0;
                MovePlayer(currentDirection);
            }
        }
        else
        {
            elapsed = 0;
            previousDirection = currentDirection;
            MovePlayer(currentDirection);
        }
    }

    public void Move(Vector2 movementVector)
    {
        if (movementVector == Vector2.zero)
        {
            currentDirection = none;
        }
        else if (Mathf.Abs(movementVector.x) > Mathf.Abs(movementVector.y))
        {
            currentDirection = movementVector.x < 0 ? left : right;
        }
        else
        {
            currentDirection = movementVector.y < 0 ? down : up;
        }
    }

    void MovePlayer(MovementDirectionSO dir)
    {
        if (dir != none)
        {
            player.Move(dir);
        }
    }
}
