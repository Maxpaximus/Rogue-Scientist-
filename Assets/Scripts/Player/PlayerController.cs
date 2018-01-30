using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpHeigt = 15;
    public float shiftSpeed = 0.5f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
    public bool doublejumed;
    bool shift;

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            shift = true;
        }
        else
        {
            shift = false;
        }
    }

    void Update ()
    {
        if (grounded)
        {
            doublejumed = false;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeigt);
            }
        }
        
        if(!grounded && !doublejumed)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeigt);
                doublejumed = true;
            }
        }
            
        if(Input.GetKey(KeyCode.D))
        { if (shift)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed + speed * shiftSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            if (shift)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed + -speed * shiftSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
       
    }
}
