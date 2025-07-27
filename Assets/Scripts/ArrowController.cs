using System.Linq;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    ObjectPool<DirectionArrow> pool;


    public void PlaceArrow(ArrowPlacementData data)
    {
        if (HasArrow(data.Position))
        {
            GetArrow(data.Position).DirectionData = data.Direction;
        }
        else
        {
            var arrow = pool.GetObject();
            arrow.MapPosition = data.Position;
            arrow.DirectionData = data.Direction;
            arrow.gameObject.SetActive(true);
        }
    }

    public bool HasArrow(Vector2Int pos)
    {
        return pool.Pool.Where(x => x.gameObject.activeInHierarchy
            && x.MapPosition == pos).Any();
    }

    public DirectionArrow GetArrow(Vector2Int pos)
    {
        return pool.Pool.Where(x => x.gameObject.activeInHierarchy
            && x.MapPosition == pos).First();
    }

    public void DisableArrows()
    {
        pool.DisableAll();
    }
}
