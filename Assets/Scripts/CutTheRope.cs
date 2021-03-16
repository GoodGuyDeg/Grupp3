using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTheRope : MonoBehaviour
{
    public Rigidbody2D bridge;
    public GameObject bridgerelease; //referens till det som håller uppe bron - Robin 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "playerflame") //Om repet nuddar elden - Robin
        {
            Playermovement.cuttherope = true;
            transform.position += new Vector3(0, 10000, 0); //Flyttar iväg repet - Robin
            bridgerelease.transform.position += new Vector3(0, 10000, 0); //Flyttar iväg på collidern som håller uppe bron - Robi

            /*bro kan nu inte flytta på sig utan att repet är borta
             för att sedan frysas igen efter 3 sekunder så att man
             inte kan flytta på den - EN*/
            bridge.constraints = RigidbodyConstraints2D.None;
            Invoke("freezebridge", 3);
        }
    }
    void freezebridge()
    {
        bridge.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
