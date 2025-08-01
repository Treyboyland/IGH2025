using UnityEngine;

public class MappedObject : MonoBehaviour
{
    static MapGrid grid;

    [SerializeField]
    Vector2Int mapPosition;

    [SerializeField]
    bool isObstacle;

    public Vector2Int MapPosition
    {
        get
        {
            return mapPosition;
        }
        set
        {
            mapPosition = value;
            UpdatePosition();
        }
    }

    public bool IsObstacle
    {
        get
        {
            return isObstacle;
        }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        grid = FindAnyObjectByType<MapGrid>();
    }

    void Start()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        grid = grid == null ? FindAnyObjectByType<MapGrid>() : grid;
        grid.SetTransformToPosition(transform, mapPosition);
    }

    public bool CanMove(MovementDirectionSO movementDirection)
    {
        var newPos = mapPosition + movementDirection.Direction;
        return grid.HasNodeAtPosition(newPos) && !grid.HasObstacleAtPosition(newPos);
    }

    public virtual void Move(MovementDirectionSO movementDirection)
    {
        var newPos = mapPosition + movementDirection.Direction;
        if (grid.HasNodeAtPosition(newPos) && !grid.HasObstacleAtPosition(newPos))
        {
            MapPosition = newPos;
        }
    }
}
