using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float TotalEnergy;
    public float CurrentEnergy = 100;
    public float LaserLenght;
    public GameObject EnergyBar;

    private Transform firepoint;

    float pitch; 

    // Use this for initialization
    void Start()
    {
        TotalEnergy = CurrentEnergy;

        firepoint = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        if (Input.GetKey(KeyCode.Mouse0) && CurrentEnergy > 0f)
        {
            RaycastHit2D hit = Physics2D.Raycast(firepoint.transform.position, transform.right * LaserLenght);
            if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
            {
                EnemyDamage enemyDamage = hit.collider.GetComponent<EnemyDamage>(); // Döp om till EnemyDamage
                if (enemyDamage != null)
                {
                    enemyDamage.TakeDamage();
                }
            }
            Debug.DrawRay(firepoint.transform.position, transform.right * LaserLenght, Color.red);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            TakeEnergy(); 
        }
        else
        {
            AddEnergy();
        }
    }

   public void TakeEnergy()
    {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy - 0.1f, 0f, TotalEnergy);
        EnergyBar.transform.localScale = new Vector3(Mathf.Clamp(CurrentEnergy / TotalEnergy, 0f, 1f), 1, 1);
       
    }

    public void TakeTimeEnergy()

    {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy - 17.5f, 0f, TotalEnergy);
        EnergyBar.transform.localScale = new Vector3(Mathf.Clamp(CurrentEnergy / TotalEnergy, 0f, 1f), 1, 1);

    }

    public void TakeParryEnergy()
    {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy - 0.1f, 0f, TotalEnergy);
        EnergyBar.transform.localScale = new Vector3(Mathf.Clamp(CurrentEnergy / TotalEnergy, 0f, 1f), 1, 1);

    }

   public void AddEnergy()
    {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy + 0.1f, 0f, TotalEnergy);
        EnergyBar.transform.localScale = new Vector3(Mathf.Clamp(CurrentEnergy / TotalEnergy, 0f, 1f), 1, 1);
    }
}
