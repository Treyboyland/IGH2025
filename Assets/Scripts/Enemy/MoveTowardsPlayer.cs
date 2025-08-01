using UnityEngine;

public class EnemyMoveTowardsPlayer : MonoBehaviour
{
    [SerializeField]
    MappedObject objToMove;

    [SerializeField]
    GameEvent onMoved;

    [SerializeField]
    float secondsBetweenMoves;

    [SerializeField]
    MovementDirectionSO up, down, left, right, none;

    static Player player;

    float elapsed = 0;

    void OnEnable()
    {
        elapsed = 0;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > secondsBetweenMoves)
        {
            elapsed = 0;
            Move();
        }
    }

    void Move()
    {
        player = player == null ? FindAnyObjectByType<Player>() : player;
        var diff = player.MapPosition - objToMove.MapPosition;
        MovementDirectionSO dir = none;
        if (diff == Vector2Int.zero)
        {
            dir = none;
        }
        else if (diff.IsXGreater())
        {
            dir = diff.x < 0 ? left : right;
            if (!objToMove.CanMove(dir))
            {
                dir = diff.y < 0 ? down : up;
            }
        }
        else
        {
            dir = diff.y < 0 ? down : up;
            if (!objToMove.CanMove(dir))
            {
                dir = diff.x < 0 ? left : right;
            }
        }
        //Debug.LogWarning($"Move: {dir.DirectionName}");
        var prev = objToMove.MapPosition;
        objToMove.Move(dir);

        if (prev != objToMove.MapPosition)
        {
            onMoved.Invoke();
        }
    }
}
