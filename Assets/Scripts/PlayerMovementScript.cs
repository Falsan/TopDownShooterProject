using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D m_rigidBody;

    Vector2 jumpForce;
    Vector2 leftForce;
    Vector2 rightForce;
    float drag;
    [SerializeField]
    int jumpCounter;
    bool touchingGround;

    // Use this for initialization
    void Start()
    {
        m_rigidBody = gameObject.GetComponent<Rigidbody2D>();
        jumpForce = new Vector2(0.0f, 3000.0f);
        leftForce = new Vector2(-100.0f, 0.0f);
        rightForce = new Vector2(100.0f, 0.0f);
        drag = 50.0f;
        m_rigidBody.drag = (drag);
        jumpCounter = 0;
        touchingGround = true;
        m_rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && jumpCounter != 1)
        {
            jumpCounter++;
            m_rigidBody.AddForce(jumpForce);
            touchingGround = false;
            //m_rigidBody.drag = (drag);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_rigidBody.AddForce(leftForce);
            m_rigidBody.drag = (drag);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_rigidBody.AddForce(rightForce);
            m_rigidBody.drag = (drag);
        }

        if(touchingGround == false)
        {
            m_rigidBody.gravityScale = 10.0f;
        }
        touchingGround = false;
    }


    void OnCollisionStay2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ground")
        {
            m_rigidBody.drag = (50.0f);
            //float difference = transform.position.y;
            m_rigidBody.gravityScale = 0.0f;
            // transform.Translate(0.0f, difference, 0.0f);
            //m_rigidBody.drag = (0.0f);
            jumpCounter = 0;
            touchingGround = true;
        }
        
       
       /* if(transform.position.y > -0.0f)
        {
            
        }
        else if (transform.position.y < 0.0f)
        {
           
        }*/
    }
}