using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chegada : MonoBehaviour
{
    private CtrlHUD HUD;
    // Start is called before the first frame update
    void Start()
    {
        HUD = GameObject.FindObjectOfType<CtrlHUD>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            HUD.AttEntregas();
        }
  
    }
}
