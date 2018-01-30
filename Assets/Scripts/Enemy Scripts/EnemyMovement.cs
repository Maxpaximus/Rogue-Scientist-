using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;

    private bool left = true;
    public float goTime = 1;
    private float lastTurn;

    public Transform humanCheck1;
    public Transform humanCheck2;
    public Transform humanCheck3;
    public float humanCheckRadius;
    public LayerMask whatIsHuman;
    public bool nearHuman1;
    public bool nearHuman2;
    public bool nearHuman3;

    public Transform player;
    private bool patroll;
    public Transform humanSighter1;
    public Transform humanSighter2;
    public bool humanInSight1;
    public bool humanInSight2;

    private void Start()
    {
        patroll = true;
        lastTurn = Time.time;
    }

    void Update ()
    {
        nearHuman1 = Physics2D.OverlapCircle(humanCheck1.position, humanCheckRadius, whatIsHuman);
        nearHuman2 = Physics2D.OverlapCircle(humanCheck2.position, humanCheckRadius, whatIsHuman);
        nearHuman3 = Physics2D.OverlapCircle(humanCheck3.position, humanCheckRadius, whatIsHuman);


        humanInSight1 = Physics2D.OverlapCircle(humanSighter1.position, humanCheckRadius, whatIsHuman);
        humanInSight2 = Physics2D.OverlapCircle(humanSighter2.position, humanCheckRadius, whatIsHuman);

        if (humanInSight1 || humanInSight2 || nearHuman1 || nearHuman2 || nearHuman3)
        {
            patroll = false;
        }

        if (left && Time.time - lastTurn >= goTime)
        {
            left = false;
            lastTurn = Time.time;
        }
        else if (!left && Time.time - lastTurn > goTime)
        {
            left = true;
            lastTurn = Time.time;
        }

		if(left && patroll)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-enemySpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (patroll)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (!patroll)
        {
            if (player.position.x < transform.position.x && !nearHuman1 && !nearHuman2 && !nearHuman3)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-enemySpeed * 1.5f, GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (!nearHuman1 && !nearHuman2 && !nearHuman3)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed * 1.5f, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        
	}
}
