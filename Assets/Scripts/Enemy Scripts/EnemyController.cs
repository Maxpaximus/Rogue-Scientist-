using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    private float meeleRange;
    public float attackRange;
    public float lastAttackTime;
    public float attackDelay;

    public DamageScript damageScript;
    

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if(distanceToPlayer < attackRange)
        {
            if(Time.time > lastAttackTime + attackDelay) {
                lastAttackTime = Time.time;
                damageScript.TakeDamage();
            }
        }
    }
}