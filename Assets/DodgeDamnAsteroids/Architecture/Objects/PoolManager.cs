using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private List<PoolableObject> prefabs = new List<PoolableObject>();
    [SerializeField] private int poolLenght = 5;
    [SerializeField] private Transform poolGO;

    private static Pool<PoolableObject> pool;
    private void Start()
    {
        pool = new Pool<PoolableObject> (prefabs, poolLenght, poolGO);
    }
    public static PoolableObject GetObject(string tag)
    {
        return pool.GetObject(tag);
    }
}
