using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    public GameObject panelInicial;
    public GameObject panelControles;
    public GameObject panelJugar;
    private GameObject currentPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnClickRetreat(){
        currentPanel.SetActive(false);
        panelInicial.SetActive(true);
        currentPanel=panelInicial;
    }
    public void OnClickJugar(){
        panelInicial.SetActive(false);
        panelJugar.SetActive(true);
        currentPanel=panelJugar;
    }
    public void OnClickControles(){
        panelInicial.SetActive(false);
        panelControles.SetActive(true);
        currentPanel=panelControles;
    }
}
