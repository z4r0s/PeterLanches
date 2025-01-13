using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform seguir;
    public Vector3 offset = new Vector3(0.04f, 2.87f, 1f);

    private void Update()
    {
        Vector3 desiredPosition = seguir.position + offset;
        desiredPosition.x = 0;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
    }
}
