using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpHeight = 15;
    public float shiftSpeed = 0.5f;
    public float groundCheckRadius;
    public float freezeDuration;
    public bool grounded;
    public bool doublejumed;
    private float lastFreeze;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public FreezingTime freezingTime;
    bool shift;
    bool slow = false;

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
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.localPosition += new Vector3(h, 0, v) * Time.fixedDeltaTime * speed;
        if (grounded)
        {
            doublejumed = false;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            }
        }
        
        if(!grounded && !doublejumed)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
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
