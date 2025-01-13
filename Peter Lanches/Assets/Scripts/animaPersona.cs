using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animaPersona : MonoBehaviour
{
    public Animator animController;

    public void Update()
    {
        if (MobileInputs.Instance.SwipeUp)
        {
            animController.SetTrigger("pulando");
        }
    }
}
