using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleasePlatform : MonoBehaviour
{
    public GameObject bridge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "playerflame") //Om repet nuddar elden - Robin
        {
            bridge.transform.position += new Vector3(0, 10000, 0); //Flyttar iväg repet - Robin
        }
    }
}
