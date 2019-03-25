using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private Text missedUnits;
   [Inject]
    private ProtectedArea protectedAreaCount;
   [Inject]
    private GameController gameController;
#if UNITY_EDITOR
    void OnValidate()
    {
        menuPanel = transform.Find("Panel-Menu").gameObject;
        restartPanel = transform.Find("Panel-Restart").gameObject;
        
    }
#endif
    
    public void ShowMenuPanel()
    {
        menuPanel.SetActive(true);
    }
    public void HideMenuPanel()
    {
        menuPanel.SetActive(false);
    }
    public void ShowRestartPanel()
    {
        restartPanel.SetActive(true);
    }
    public void HideRestartPanel()
    {
        restartPanel.SetActive(false);
    }

    public void OnExitBtn()
    {
        gameController.Exit();
    }

    public void OnPlayBtn()
    {
        gameController.Play();
    }

    public void OnRestartBtn()
    {
        gameController.Restart();
    }

    void Update()
    {
        missedUnits.text = "Missed:"+ protectedAreaCount.MissUnit.ToString();
    }
}
