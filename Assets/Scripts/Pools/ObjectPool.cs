using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    protected T prefab;

    protected List<T> pool = new List<T>();

    T CreateObject()
    {
        var newPrefab = Instantiate(prefab, transform);
        newPrefab.gameObject.SetActive(false);
        pool.Add(newPrefab);
        return newPrefab;
    }

    public T GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateObject();
    }

    public void DisableAll()
    {
        foreach (var obj in pool)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public int GetNumActive()
    {
        return pool.Where(x => x.gameObject.activeInHierarchy).Count();
    }

    public List<T> GetActiveObjects()
    {
        return pool.Where(x => x.gameObject.activeInHierarchy).ToList();
    }
}
