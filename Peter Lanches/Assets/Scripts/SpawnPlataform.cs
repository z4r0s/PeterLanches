using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataform : MonoBehaviour
{
    public List<GameObject> plataforms = new List<GameObject>();
    public List<Transform> currentplataforms = new List<Transform>();
    public float offset;
    private Transform player;
    private Transform currentPlataformPoint;
    private int platIndex;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < plataforms.Count; i++)
        {
            Transform p = Instantiate(plataforms[i], new Vector3(0,0,i * 17.6f),Quaternion.Euler(0, 0, 0)).transform;
            currentplataforms.Add(p);
            offset += 17.6f;
        }

        currentPlataformPoint = currentplataforms[platIndex].GetComponent<Plataform>().point;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = player.position.z - currentPlataformPoint.position.z;

        if(distance >= 5)
        {
            Recycle(currentplataforms[platIndex].gameObject);
            platIndex++;

            if (platIndex > currentplataforms.Count - 1)
            {
                platIndex = 0;
            }

            currentPlataformPoint = currentplataforms[platIndex].GetComponent<Plataform>().point;
            
        }
    }
    public void Recycle(GameObject plataform)
    {
        plataform.transform.position = new Vector3(0, 0, offset);
        offset += 17.6f; 
    }
}
