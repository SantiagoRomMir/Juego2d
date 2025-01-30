using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void Facil(){
        PlayerPrefs.SetInt("dificultad",0);
        PlayerPrefs.SetFloat("dificultadV",0.75f);
        cambiarEscena();
    }
    public void Normal(){
        PlayerPrefs.SetInt("dificultad",1);
        PlayerPrefs.SetFloat("dificultadV",1f);
        cambiarEscena();
    }
    public void Dificil(){
        PlayerPrefs.SetInt("dificultad",2);
        PlayerPrefs.SetFloat("dificultadV",1.25f);
        cambiarEscena();
    }
    private void cambiarEscena(){
        SceneManager.LoadScene(1);
    }
}
