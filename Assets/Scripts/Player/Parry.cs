using UnityEngine;

public class Parry : MonoBehaviour
{
    public GameObject sphere;
    private MeshRenderer sphereMesh;
    private CircleCollider2D circleCollider;

    public float parryTime;
    private float lastParry;
    public Laser laser;
    private bool parryActive;
    public DamageScript damageScript;

	// Use this for initialization
	void Start ()
    {
        sphereMesh = sphere.GetComponent<MeshRenderer>();
        sphereMesh.enabled = false;

        circleCollider = sphere.GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
        lastParry = Time.time - parryTime;

    }
	
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.X) && laser.currentEnergy > 24)
        {
            parry();
            laser.TakeParryEnergy();
            parryActive = true;
            lastParry = Time.time;
        }
        else
        {
            parryActive = false;
        }


        if (parryActive && Time.time - lastParry < parryTime)
        {
            
            sphereMesh.enabled = true;
            circleCollider.enabled = true;
            parryActive = true;
        }
        else if (Time.time - lastParry > parryTime)
        {
            sphereMesh.enabled = false;
            circleCollider.enabled = false;
            damageScript.NotParried();
        }
        
	}
    void parry()
    {
        sphereMesh.enabled = true;
        circleCollider.enabled = true;
        damageScript.Parried();
    }
}
