using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlHud : MonoBehaviour
{

    public Slider lifeBar;
    public TextMeshProUGUI textMoney;
    public TextMeshProUGUI textLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLife(int vidaActual, int vidaMax){
        lifeBar.value=(float)vidaActual/vidaMax;
        textLife.text=vidaActual.ToString();
    }
    public void SetMoney(int Money){
        textMoney.text="Pasta: "+ Money.ToString();
        
    }
}
