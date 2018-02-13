using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeedController : MonoBehaviour
{
    public FreezingTime freezingTime;

    //Enemy movement values
    public float enemySpeed; //Decrease during "FreezeTime"
    public float goTime; //Increase

    //Arrow movement values
    public float speedUp; //Decrease
    public float timeUp; //Increase
    public float timeDown; //Increase
    public float waitTime; //Increase

    //Melee attack values
    public float attackDelay; //Increase

    public void FreezeTime()
    {
        //enemySpeed = enemySpeed /
    }
}
