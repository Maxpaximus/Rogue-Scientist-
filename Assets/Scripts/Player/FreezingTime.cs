using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingTime : MonoBehaviour
{
    public Laser laser;

    public float cooldownFreeze;
    public float lastFreeze;
    public float timeFreezeMultiplier = 0.5f;

    public EnemySpeedController enemySpeedController;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && laser.currentEnergy > 49 && Time.time - lastFreeze > cooldownFreeze)
        {
            lastFreeze = Time.time;
            laser.TakeTimeEnergy();
            enemySpeedController.FreezeTime();
        }

    }
}


    
    