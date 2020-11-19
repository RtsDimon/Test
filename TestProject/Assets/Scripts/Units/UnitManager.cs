using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DimonPool;
public class UnitManager : MonoBehaviour
{
    static public UnitManager instance;
    public List<Unit> units;

    [Header("AutoSpawn")]
    [SerializeField] PoolMain pool;
    [SerializeField] float range = 10.0f;
    float t;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SpawnRandom();
    }
    private void SpawnRandom()
    {
        for (int i = 0; i < pool.pools.Count; i++)
        {
            for (int q = 0; q < pool.pools[i].size; q++)
            {
                Vector3 pos = new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
                pool.Spawn(pool.pools[i].tag, transform.position + pos, Quaternion.identity);
            }
        }
        
    }
    void Update()
    {

        for (int i = 0; i < units.Count; i++)
        {
            Unit unit = units[i];
            unit.UpdateMe();
        }
    }
    private void OnDrawGizmos()
    {
        float scale = range * 2;
        Gizmos.DrawWireCube(transform.position,new Vector3(scale, scale, scale));
    }
}
