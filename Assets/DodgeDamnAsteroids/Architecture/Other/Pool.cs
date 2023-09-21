using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private List<T> prefabs;

    private List<T> pool;

    public Pool(List<T> prefabs, int poolLenght, Transform poolGO = null)
    {
        this.prefabs = prefabs;
        pool = new List<T>();

        foreach (T prefab in prefabs)
        {
            for (int i = 0; i < poolLenght; i++)
            {
                var obj = CreateObject(prefab);

                if (poolGO != null)
                    obj.transform.SetParent(poolGO);
            }
        }
    }

    public T GetObject(string tag)
    {
        if (!pool.Exists(x => x.CompareTag(tag)))
        {
            Debug.LogError("There is no objects with this tag in the Pool!");
        }

        var obj = pool.FirstOrDefault(x => !x.isActiveAndEnabled && x.CompareTag(tag));

        if (obj == null)
            obj = CreateObject(prefabs.First(x => x.CompareTag(tag)));
        
        obj.gameObject.SetActive(true);
        return obj;
    }

    private T CreateObject(T prefab)
    {
        var obj = GameObject.Instantiate(prefab);
        obj.gameObject.SetActive(false);
        pool.Add(obj);
        return obj;
    }

}
