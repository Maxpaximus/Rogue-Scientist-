using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour {

    public float Health;
    public float Damage;

    public void TakeDamage()
    {
        Health -= Damage;
        if (Health <= 0f)
        {
            Destroy(gameObject);
        }
        
    }
}
