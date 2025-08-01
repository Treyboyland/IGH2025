using System.Linq;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    [SerializeField]
    float distancePerUnit = 1;

    [Tooltip("Value doubled. Dimension 5,5 will yield grid spanning from -5,-5 to 5,5")]
    [SerializeField]
    Vector2Int dimensions;

    [SerializeField]
    ObjectPool<MapNode> pool;

    public Vector2Int Dimensions { get => dimensions; }

    void Awake()
    {
        GenerateNodes();
    }

    void GenerateNodes()
    {
        Vector2Int posDim = new Vector2Int(Mathf.Abs(dimensions.x), Mathf.Abs(dimensions.y));

        for (int x = -posDim.x; x <= posDim.x; x++)
        {
            for (int y = -posDim.y; y <= posDim.y; y++)
            {
                var node = pool.GetObject();
                node.gameObject.SetActive(true);
                node.MapPosition = new Vector2Int(x, y);
                node.transform.position = new Vector2(x, y) * distancePerUnit;
            }
        }
    }

    public bool HasNodeAtPosition(Vector2Int pos)
    {
        return pool.GetActiveObjects().Where(x => x.MapPosition == pos).Any();
    }

    public MapNode GetNodeAtPosition(Vector2Int pos)
    {
        if (HasNodeAtPosition(pos))
        {
            return pool.GetActiveObjects().Where(x => x.MapPosition == pos).First();
        }
        return null;
    }

    public void SetTransformToPosition(Transform transform, Vector2Int pos)
    {
        transform.position = GetNodeAtPosition(pos).transform.position;
    }

    public bool HasObstacleAtPosition(Vector2Int pos)
    {
        return FindObjectsByType<MappedObject>(FindObjectsInactive.Exclude, FindObjectsSortMode.None)
            .Where(x => x.MapPosition == pos && x.IsObstacle == true).Any();
    }
}
