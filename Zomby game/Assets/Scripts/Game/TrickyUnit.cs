using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrickyUnit : MonoBehaviour
{
    [Inject] private GameConfig gameConfig;
    private float side = 0f;
    private float speed;
    [SerializeField]
    private GameObject unit;
    private float maxSpeed;
    private float minSpeed;

    void Aweke()
    {
        maxSpeed = gameConfig.EnemyMaxSpeed;
        minSpeed = gameConfig.EnemyMinSpeed;
    }
    void Start()
    {
   //     StartCoroutine(Side());
    }
  //  IEnumerator Side()
  //  {
    //    while (true)
    //    {
    //        side = Random.Range(0f, 1f);
    //        speed = Random.Range(minSpeed, maxSpeed);
    //        yield return new WaitForSeconds(1.5f);
    //    }
    //}
    void Update()
    {
        transform.Translate(Vector3.down * Random.Range(maxSpeed, minSpeed) * Time.deltaTime);
        if (unit.transform.position.y <= -6f)// 6f ti end 
        {
            unit.SetActive(false);
        }
      //  if (side >= 0.5f)
       // {
          //    transform.position -= new Vector3(-side * Time.deltaTime, 0, 0);
            
           // transform.Translate(Random.Range(minSpeed, maxSpeed) * Time.deltaTime, -1 * Time.deltaTime, 0);
     //   }
     //   if (side <= 0.5)
      //  {
         //    transform.position -= new Vector3(side * Time.deltaTime,0, 0);
          // transform.Translate(Vector3.down * speed * Time.deltaTime);
          // transform.position -= new Vector3(0.5f * Time.deltaTime, Random.Range(minSpeed, maxSpeed) * Time.deltaTime, 0);
      //  }
    }
}
