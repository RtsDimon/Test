using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimonPool
{
    public class PoolMain : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public PoolObject prefab;
            public int size;

        }
        static public PoolMain instance;
        public List<Pool> pools;
        public Dictionary<string, Queue<PoolObject>> poolDir;
        private void Awake()
        {
            instance = this;
        }
        private void Start() // creating pools
        {

            poolDir = new Dictionary<string, Queue<PoolObject>>();
            foreach (Pool pool in pools)
            {
                Queue<PoolObject> objectPool = new Queue<PoolObject>();
                for (int i = 0; i < pool.size; i++)
                {
                    PoolObject g = Instantiate(pool.prefab);
                    g.gameObject.SetActive(false);
                    g.Init();
                    objectPool.Enqueue(g);
                }
                poolDir.Add(pool.tag, objectPool);
            }
        }
        public GameObject Spawn(string tag, Vector3 pos, Quaternion rot)
        {

            if (!poolDir.ContainsKey(tag))
            {
                print("tag " + tag + " is not exist");
                return null;
            }

            if (poolDir[tag].Count != 0)
            {
                PoolObject obj = poolDir[tag].Peek();
                if (obj.ready == true)
                {
                    poolDir[tag].Dequeue();

                    obj.transform.position = pos;
                    obj.transform.rotation = rot;
                    obj.gameObject.SetActive(true);
                    obj.OnSpawn();
                }
                return obj.gameObject;
            }

            return null;


        }
    }
}

