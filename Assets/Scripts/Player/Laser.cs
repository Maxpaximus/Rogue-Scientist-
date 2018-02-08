using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float totalEnergy;
    public float currentEnergy = 100;
    public float laserLength;
    public GameObject energyBar;

    private Transform firepoint;

    float pitch; 

    // Use this for initialization
    void Start()
    {
        totalEnergy = currentEnergy;

        firepoint = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        if (Input.GetKey(KeyCode.Mouse0) && currentEnergy > 0f)
        {
            RaycastHit2D hit = Physics2D.Raycast(firepoint.transform.position, transform.right * laserLength);
            if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
            {
                EnemyDamage enemyDamage = hit.collider.GetComponent<EnemyDamage>(); // Döp om till EnemyDamage
                if (enemyDamage != null)
                {
                    enemyDamage.TakeDamage();
                }
            }
            Debug.DrawRay(firepoint.transform.position, transform.right * laserLength, Color.red);
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
        currentEnergy = Mathf.Clamp(currentEnergy - 0.1f, 0f, totalEnergy);
        energyBar.transform.localScale = new Vector3(Mathf.Clamp(currentEnergy / totalEnergy, 0f, 1f), 1, 1);
       
    }

    public void TakeTimeEnergy()
    {
        currentEnergy = Mathf.Clamp(currentEnergy - 50f, 0f, totalEnergy);
        energyBar.transform.localScale = new Vector3(Mathf.Clamp(currentEnergy / totalEnergy, 0f, 1f), 1, 1);

    }

    public void TakeParryEnergy()
    {
        currentEnergy = Mathf.Clamp(currentEnergy - 20f, 0f, totalEnergy);
        energyBar.transform.localScale = new Vector3(Mathf.Clamp(currentEnergy / totalEnergy, 0f, 1f), 1, 1);

    }

    public void AddEnergy()
    {
        currentEnergy = Mathf.Clamp(currentEnergy + 0.1f, 0f, totalEnergy);
        energyBar.transform.localScale = new Vector3(Mathf.Clamp(currentEnergy / totalEnergy, 0f, 1f), 1, 1);
    }
}
