using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{
    public static bool IsXGreater(this Vector2 vect)
    {
        return Mathf.Abs(vect.x) > Mathf.Abs(vect.y);
    }

    public static bool IsXGreater(this Vector2Int vect)
    {
        return Mathf.Abs(vect.x) > Mathf.Abs(vect.y);
    }

    public static T GetRandomItem<T>(this List<T> list)
    {
        int chosenIndex = Random.Range(0, list.Count);
        return list[chosenIndex];
    }
}
