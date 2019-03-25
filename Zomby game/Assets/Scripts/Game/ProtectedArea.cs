using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProtectedArea : MonoBehaviour
{
    [Inject]
    private UIController uiController;

    private int missUnit;
    public int Survivors { get => survivors;  }
    public int MissUnit { get => missUnit;  }

    private int survivors;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("col");
        if (other.gameObject.tag == "zombe_0")
        {
            missUnit++; 
        }
        if (other.gameObject.tag == "human")
        {
            survivors++;
        }
    }
}
