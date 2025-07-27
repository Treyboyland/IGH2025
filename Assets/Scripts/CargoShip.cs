using UnityEngine;

public class CargoShip : MappedObject
{
    [SerializeField]
    float secondsBetweenMoves;

    [SerializeField]
    GameEvent<Vector3> goalReached;

    float elapsed = 0;

    static ArrowController arrowController;

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > secondsBetweenMoves)
        {
            CheckMovementDirection();
        }
    }

    void CheckMovementDirection()
    {
        arrowController = arrowController == null ? FindAnyObjectByType<ArrowController>() : arrowController;
        if (arrowController.HasArrow(MapPosition))
        {
            elapsed = 0;
            Move(arrowController.GetArrow(MapPosition).DirectionData);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var goal = collision.gameObject.GetComponent<GoalNode>();
        if (goal != null)
        {
            goalReached.Invoke(transform.position);
            gameObject.SetActive(false);
        }
    }
}
