using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    public static Coletaveis Instance { set; get; }
    private CtrlHUD HUD;
    public bool coleta;
    public bool Coleta { get { return coleta; } }

    void Start()
    {
        HUD = GameObject.FindObjectOfType<CtrlHUD>();
    }


    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            coleta = false;
            this.gameObject.SetActive(coleta);
            HUD.SomPwrUp();
            HUD.AttMoedas();
        }
    }

}
