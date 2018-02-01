using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingTime : MonoBehaviour
{
    public Laser laser;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && laser.CurrentEnergy > 0)
        {
            laser.TakeTimeEnergy();
            Debug.Log("hej");
        }
    }
}

    
    