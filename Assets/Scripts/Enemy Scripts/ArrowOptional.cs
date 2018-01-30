using UnityEngine;

public class ArrowOptional : MonoBehaviour {

    public float forceUp;
   
    public Transform target;
    public float timeUp;
    public float timeDown;
    private float lastTurn;
    private bool up;
    
    public Transform arrowSpawn;

	
	void Start ()
    {
        lastTurn = Time.time;
        up = true;
        
	}
	
	
	void Update ()
    {
        if (Time.time - lastTurn <= timeUp && up)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(target.position.x / (timeUp * 2), forceUp);
            
        }
        else if (Time.time - lastTurn > timeUp && up)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(target.position.x - transform.position.x, -transform.position.y + target.position.y);
            up = false;
            lastTurn = Time.time;
        }

        if (Time.time - lastTurn >= timeDown && !up)
        {

            transform.position = new Vector2(arrowSpawn.position.x, arrowSpawn.position.y);
            up = true;
            lastTurn = Time.time;
            
        }
        

	}
}
