using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class Touchcontroller : MonoBehaviour
{
    private PoolObj poolObj;
    [Inject]
    private GameConfig confController;
    [Inject]
    private UIController uiController;
    // status game true we play false we loose
    // Start is called before the first frame update
    void Start()
    {
        poolObj = PoolObj.Instance;
    }

    public void LoseGame()
    {
        confController.GameStatus = false;
        uiController.ShowRestartPanel();
    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown((0))) // using in editor.
        {
            Debug.Log("srartGetMouseButtonDown");

           Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if  (hit.collider != null)
            {
                Debug.Log("hitting " + hit.collider.tag);
                GameObject touchedObject = hit.collider.gameObject;
                switch (touchedObject.tag)
                {
                    case "zombe_0":
                        Debug.Log("rey touch : " + touchedObject.tag);
                        //poolObj.ReturnFromPool("Enemy");
                        touchedObject.SetActive(false);
                        break;
                    case "human":
                        Debug.Log("rey touch : " + touchedObject.tag);
                        //poolObj.ReturnFromPool("Human");
                        touchedObject.SetActive(false);
                        LoseGame();
                        break;
                    default:
                        break;
                }
            }

        }
#endif
        if (Input.touchCount > 0 )
        {
            Debug.Log("srart.touchCount");
            //We should have hit something with a 2D Physics collider!
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
           
            var touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
            if(hitInformation.collider != null)
            {
                Debug.Log("hitting " + hitInformation.collider.tag);
                GameObject touchedObject = hitInformation.collider.gameObject;
                switch (touchedObject.tag)
                {
                    case "zombe_0":
                        Debug.Log("rey touch "+ touchedObject.tag);
                        poolObj.ReturnFromPool("Enemy");
                        break;
                    case "human":
                        Debug.Log("rey touch "+ touchedObject.tag);
                        poolObj.ReturnFromPool("Human");
                        break;
                    default:
                        break;
                }
              
            }
        }

        //Debug.DrawLine(transform.position, transform.position + transform.right);
        ////We also check if the first touches phase is Ended (that the finger was lifted)
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        //{
        //    //We transform the touch position into word space from screen space and store it.
        //    var touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //    Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
        //    //We now raycast with this information. If we have hit something we can process it.
        //    RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
        //    if (hitInformation.collider != null)
        //    {
        //        //We should have hit something with a 2D Physics collider!
        //        GameObject touchedObject = hitInformation.transform.gameObject;
        //        var objName = touchedObject.transform.name;
        //        switch (objName)
        //        {
        //            case "zombe_0":
        //                Debug.Log("rey" + objName);
        //                poolObj.ReturnFromPool("Enemy");
        //                break;
        //            default:
        //                break;
        //        }

        //        Debug.Log("Touched " + touchedObject.transform.name);
        //    }
        //}
    }
}
