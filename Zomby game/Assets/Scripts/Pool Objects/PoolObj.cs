using System.Collections.Generic;
using UnityEngine;


public class PoolObj : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #region Singltone // Singleton if dosen't use zenject

    public static PoolObj Instance;

    private void Awake()
    {
        Instance = this;
    }
#endregion
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictinary;
    // Start is called before the first frame update
    void Start()
    {
        poolDictinary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); 

            for (int i = 0; i < pool.size; i++)
            {
                GameObject objInst = Instantiate(pool.prefab);
                objInst.SetActive(false);
                objectPool.Enqueue(objInst);     //Enqueue() add in end Queue
            }
            poolDictinary.Add(pool.tag, objectPool);
        }
    }
    //method spawner obj
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictinary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictinary[tag].Dequeue();

       objectToSpawn.SetActive(true);
       objectToSpawn.transform.position = position;
       objectToSpawn.transform.rotation = rotation;
       poolDictinary[tag].Enqueue(objectToSpawn);
       IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

       if (pooledObject != null)
       {
           pooledObject.OnSpawnObj();
       }
       return objectToSpawn;
    }

    public GameObject ReturnFromPool(string tag)
    {
        GameObject objectToSpawn = poolDictinary[tag].Dequeue();

        objectToSpawn.SetActive(false);
        poolDictinary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
