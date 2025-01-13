using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{

    private CtrlHUD HUD;
    private MobileInputs Input;

    void Start()
    {
        HUD = GameObject.FindObjectOfType<CtrlHUD>();
        Input = GameObject.FindObjectOfType<MobileInputs>();
    }

    void OnTriggerEnter(Collider obj)
    {
        if(MobileInputs.Instance.Cheat == true)
        {

        }
        else
        {
            if (obj.tag == "Player")
            {
                Destroy(this.gameObject);
                HUD.SomAbatido();
                HUD.GameOver();
                Time.timeScale = 0;
            }
        }
       
    }
}
