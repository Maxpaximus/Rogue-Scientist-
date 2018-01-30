using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageScript : MonoBehaviour {

    public string gameOver;
    public int health = 100;
    public int damage = 20;
    public int hitpoints = 3;
    public BoxCollider2D player;
    public SceneManager Gameoverscene;

    private bool parried = false;

    public Collider2D NULL { get; private set; }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Enemy" || hit.gameObject.tag == "Arrows")
        {
            TakeDamage();
           

        }
    }
    public void Parried()
    {
        parried = true;
    }
     
    public void NotParried()
    {
        parried = false;
    }

    public void TakeDamage()
    {
        if (!parried)
        {
            PlayerPrefs.SetInt("hitPoints", hitpoints);
            PlayerPrefs.Save();

            health -= damage;
            if (health == 0)
            {
                hitpoints = PlayerPrefs.GetInt("hitPoints", 3);
                hitpoints -= 1;
                health = 100;
                PlayerPrefs.SetInt("hitPoints", hitpoints);
                PlayerPrefs.Save();
            }

            if (hitpoints == 0)
            {
                SceneManager.LoadScene(gameOver);
            }
        }
    }
  }


