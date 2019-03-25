using UnityEngine;
using Zenject;

public class Spawn : MonoBehaviour, IPooledObject
{
    /// <summary>
    /// Example of how to pull objects out of the pool
    /// </summary>
    private PoolObj poolObj;
    [SerializeField]
    private float timeEnemy;
    [SerializeField]
    private float timeHuman;
    [SerializeField]
    private float timeTricky;
    [Inject]
    private GameConfig confController;

    private int numSpawnObj;
    private void Start()
    {
        poolObj = PoolObj.Instance;
        timeEnemy = confController.TimeToSpawnEnemy;
        timeHuman = confController.TimeToSpawnSurvivor;
        timeTricky = confController.TimeSpawnTricky;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (confController.GameStatus) // if game start, start timer
        {
            if (timeEnemy > 0 || timeHuman>0|| timeTricky>0)
            {
                timeEnemy -= Time.deltaTime;
                timeHuman -= Time.deltaTime;
                timeTricky -= Time.deltaTime;
            }
            if (timeEnemy <= 0 )
            {
                OnSpawnObj();
                numSpawnObj = 1;
            }
            if (timeTricky <= 0)
            {
                OnSpawnObj();
                numSpawnObj = 2;
            }
            if (timeHuman <= 0)
            {
                OnSpawnObj();
                numSpawnObj = 3;
            }
        }
        
    }

    public void OnSpawnObj()
    {
        switch (numSpawnObj)
        {
            case 1:
                poolObj.SpawnFromPool("Enemy", new Vector3(Random.Range(-2f,2f),6,0), Quaternion.identity);
                timeEnemy = confController.TimeToSpawnEnemy;
                break;
            case 2:
                poolObj.SpawnFromPool("Enemy Side", new Vector3(Random.Range(-2f, 2f), 6, 0), Quaternion.identity);
                timeTricky= confController.TimeSpawnTricky;
                break;
            case 3:
                poolObj.SpawnFromPool("Human", new Vector3(Random.Range(-2f, 2f), 6, 0), Quaternion.identity);
                timeHuman = confController.TimeToSpawnSurvivor;
                break;
            default:
                break;
        }
        
    }

}
