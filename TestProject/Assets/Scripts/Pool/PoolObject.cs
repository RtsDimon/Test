using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimonPool
{
    public class PoolObject : MonoBehaviour
    {
        public bool ready = false;
        [HideInInspector] public PoolMain pool;
        [SerializeField] string tagPool;

        [SerializeField] bool autoEnqueue = false;

        [SerializeField] float lifeTime;

        public void Init()
        {
            pool = PoolMain.instance;
            ready = true;
        }
        private IEnumerator LifeTime(float timer)
        {


            while (true)
            {
                yield return null;
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    OnDeath();
                    break;
                }
            }
        }

        public virtual void OnSpawn()
        {
            if (autoEnqueue)
            {
                pool.poolDir[tagPool].Enqueue(this);
                return;
            }
            if (lifeTime > 0)
            {
                StartCoroutine(LifeTime(lifeTime));
            }
            ready = false;
        }
        public virtual void OnDeath()
        {

            pool.poolDir[tagPool].Enqueue(this);
            gameObject.SetActive(false);
            ready = true;
        }

    }
}
