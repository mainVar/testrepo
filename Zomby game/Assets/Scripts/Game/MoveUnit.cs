using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoveUnit : MonoBehaviour
{

    [Inject]
    private GameConfig confController;
    [SerializeField]
    private GameObject unit;
    private float maxSpeed=5;
    private float minSpeed=1;

    void Aweke()
    {
       maxSpeed = confController.EnemyMaxSpeed;
       minSpeed = confController.EnemyMinSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Random.Range(maxSpeed, minSpeed) * Time.deltaTime);
        if (unit.transform.position.y <= -6f)
        {
            unit.SetActive(false);
        }
    }

}
