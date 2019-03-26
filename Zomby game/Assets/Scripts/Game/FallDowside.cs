using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FallDowside : MonoBehaviour
{
    
   
    [Inject]
    private GameConfig confController;
    [SerializeField]
    private GameObject unit;
    private float maxSpeed;
    private float minSpeed;
    private float fall_speed;
    private float side;

    void Aweke()
    {
        maxSpeed = confController.EnemyMaxSpeed;
        minSpeed = confController.EnemyMinSpeed;
    }
    void Start()
    {
        StartCoroutine(Side());
        fall_speed = Random.Range(minSpeed, maxSpeed);
        fall_speed = 2f;// It's a crutch! and I know that blame fall_speed = Random.Range (minSpeed, maxSpeed);
    }
    IEnumerator Side()
    {
        while (true)
        {
           
            side = Random.Range(0f, 1f);
            
            yield return new WaitForSeconds(1.5f);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (unit.transform.position.y <= -6f)
        {
            unit.SetActive(false);
        }
        //transform.Translate(Vector3.down * Random.Range(maxSpeed, minSpeed) * Time.deltaTime);
        if (side >= 0.5f)
        {
            transform.position -= new Vector3(Mathf.Clamp(-0.5f * Time.deltaTime, -2f, 2f), fall_speed * Time.deltaTime, 0);

        }
        if (side <= 0.5)
        {
            transform.position -= new Vector3(Mathf.Clamp(0.5f * Time.deltaTime, -2f, 2f), fall_speed * Time.deltaTime, 0);
        }

    }
}

