using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig",menuName = "Create game config")]
public class GameConfig : ScriptableObject
{
    public float EnemyMaxSpeed;                          // 
    public float EnemyMinSpeed;                          // SurvivorSpeed to;
   // public float SurvivorSpeed;
    public float TimeToSpawnEnemy;                       // usual zombi
    public float TimeSpawnTricky;                        //tricky zombi
    public float TimeToSpawnSurvivor;
    public bool GameStatus=false;                         // true -> playing
}
