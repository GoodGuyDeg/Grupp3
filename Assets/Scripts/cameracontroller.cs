using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public GameObject player; //referens till player - Robin
    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10); //sätter kameran till playerns position - Robin
    }
}
