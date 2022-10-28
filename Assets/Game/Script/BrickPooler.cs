using System.Collections.Generic;
using UnityEngine;

namespace Game.Script
{
    public class BrickPooler : MonoBehaviour
    {
        public static BrickPooler BrickInstance;
        public List<GameObject> pooledObjects;
        public GameObject objectBrick;
        public int amountToPool;

        public bool expand = true;

        void Awake()
        {
            BrickInstance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Instantiate(objectBrick);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        public GameObject GetObject()
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }

            if (expand)
            {
                GameObject obj = Instantiate(objectBrick);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
            else
            {
                return null;
            }
        }

        public void UpdatePosition()
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (pooledObjects[i].activeInHierarchy)
                {
                    pooledObjects[i].transform.position = new Vector3(pooledObjects[i].transform.position.x, pooledObjects[i].transform.position.y - 0.5f, 0);
                }
            }
        }
    }
}