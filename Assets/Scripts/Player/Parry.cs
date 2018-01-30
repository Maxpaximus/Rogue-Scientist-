using UnityEngine;

public class Parry : MonoBehaviour
{
    public GameObject sphere;
    private MeshRenderer sphereMesh;
    private CircleCollider2D circleCollider;

    public float parryTime;
    public float lastParry;
    private float parryCooldown;
    public float parryCoolown2;

    public DamageScript damageScript;

	// Use this for initialization
	void Start ()
    {
        sphereMesh = sphere.GetComponent<MeshRenderer>();
        sphereMesh.enabled = false;

        circleCollider = sphere.GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;

        parryCooldown = 0;
    }
	
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.X) && Time.time - lastParry >= parryCooldown)
        {
            lastParry = Time.time;
            parry();
           
        }

        if (Time.time - lastParry >= parryTime)
        {
            sphereMesh.enabled = false;
            circleCollider.enabled = false;
            damageScript.NotParried();
        }
        
	}
    void parry()
    {
        parryCooldown = parryCoolown2;
        sphereMesh.enabled = true;
        circleCollider.enabled = true;
        damageScript.Parried();
    }
}
