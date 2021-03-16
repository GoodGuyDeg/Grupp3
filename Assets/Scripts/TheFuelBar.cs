using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheFuelBar : MonoBehaviour
{
    public Slider slider; //referens till fuelens slider - Robin
    
    public void SetMaxFuel(float fuel) //Sätter sliderns max fuel value - Robin
    {
        slider.maxValue = fuel;
        slider.value = fuel;
    }

    public void SetHealth(float fuel) //sätter sliderns nuvarande fuel - Robin
    {
        slider.value = fuel;
    }
}
