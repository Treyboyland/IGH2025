using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MappedObject
{
    [SerializeField]
    List<MovementDirectionSO> arrowDirections;

    [SerializeField]
    int directionIndex;

    [SerializeField]
    GameEvent<Vector3> onDeath;

    [SerializeField]
    GameEvent<MovementDirectionSO> onDirectionUpdated;

    [SerializeField]
    GameEvent<ArrowPlacementData> onArrowPlaced;

    MovementDirectionSO currentDirection => arrowDirections[directionIndex];

    public bool IsPlayerInvincible { get; set; } = false;

    void Start()
    {
        onDirectionUpdated.Invoke(currentDirection);
    }

    public void Die()
    {
        if (!IsPlayerInvincible)
        {
            onDeath.Invoke(transform.position);
            gameObject.SetActive(false);
        }
    }

    public void IncrementDirection()
    {
        //Debug.LogWarning("Incrementing Direction");
        directionIndex = (directionIndex + 1) % arrowDirections.Count;
        onDirectionUpdated.Invoke(currentDirection);
    }

    public void DecrementDirection()
    {
        directionIndex--;
        if (directionIndex < 0)
        {
            directionIndex = arrowDirections.Count - 1;
        }
        onDirectionUpdated.Invoke(currentDirection);
    }

    public void PlaceArrow()
    {
        onArrowPlaced.Invoke(new ArrowPlacementData()
        {
            Direction = currentDirection,
            Position = MapPosition
        });
    }

    public void ResetPosition()
    {
        MapPosition = Vector2Int.zero;
    }
}
