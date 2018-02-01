using UnityEngine;

public class ArrowOptional : MonoBehaviour {

    public float forceUp;
   
    public Transform target;
    public float timeUp;
    public float timeDown;
    private float lastTurn;
    private bool up;
    public float waitTime;
    private float lastLanding;
    private float timeUp2;

    private bool arrowThrow;
    
    public Transform arrowSpawn;

    public GameObject arrow;
    private SpriteRenderer arrowMesh;
    private BoxCollider2D arrowCollider;

	
	void Start ()
    {
        timeUp2 = timeUp;
        lastTurn = Time.time;
        lastLanding = Time.time - waitTime;
        up = true;

        arrowMesh = arrow.GetComponent<SpriteRenderer>();
        arrowCollider = arrow.GetComponent<BoxCollider2D>();

    }
	
	
	void Update ()
    {
        if (Time.time - lastLanding <= waitTime)
        {
            arrowThrow = false;
            transform.position = new Vector2(arrowSpawn.position.x, arrowSpawn.position.y);

            arrowCollider.enabled = false;
            arrowMesh.enabled = false;
        }
        else
        {
            arrowCollider.enabled = true;
            arrowMesh.enabled = true;
            arrowThrow = true;
        }

        if (Time.time - lastTurn <= timeUp && up && arrowThrow)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2((target.position.x - transform.position.x) / 2, forceUp);
            
        }
        else if (Time.time - lastTurn > timeUp && up && arrowThrow)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2((target.position.x - transform.position.x) / timeDown, (-transform.position.y + target.position.y) / timeDown);
            up = false;
            lastTurn = Time.time;
        }

        if (Time.time - lastTurn >= timeDown && !up && arrowThrow)
        {

            transform.position = new Vector2(arrowSpawn.position.x, arrowSpawn.position.y);
            up = true;
            lastTurn = Time.time;
            lastLanding = Time.time;
            timeUp = timeUp2 + waitTime;

        }
        

	}
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (arrowThrow)
        {
         transform.position = new Vector2(arrowSpawn.position.x, arrowSpawn.position.y);
         up = true;
         lastTurn = Time.time;
         lastLanding = Time.time;
         timeUp = timeUp2 + waitTime;
        }
    }
}
