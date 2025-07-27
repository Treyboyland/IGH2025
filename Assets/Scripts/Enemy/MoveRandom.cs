using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    [SerializeField]
    MappedObject objToMove;

    [SerializeField]
    float secondsBetweenMoves;

    [SerializeField]
    MovementDirectionSO up, down, left, right, none;

    static Player player;

    float elapsed = 0;

    List<MovementDirectionSO> potentialMoves;

    void OnEnable()
    {
        elapsed = 0;

        potentialMoves = new List<MovementDirectionSO>()
        {
            up, down, left, right, none
        };
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
        var dir = potentialMoves.GetRandomItem();
        objToMove.Move(dir);
    }
}
