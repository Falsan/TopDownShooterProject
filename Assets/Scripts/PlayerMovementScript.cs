using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D m_rigidBody;

    Vector3 up;
    Vector3 left;
    Vector3 right;
    Vector3 down;
    Vector3 var;
    Vector3 moveVector;
    float drag;

    // Use this for initialization
    void Start()
    {
        m_rigidBody = gameObject.GetComponent<Rigidbody2D>();
        up = new Vector3(0.0f, 100.0f);
        left = new Vector3(-100.0f, 0.0f);
        right = new Vector3(100.0f, 0.0f);
        down = new Vector3(0.0f, -100.0f);
        moveVector = new Vector3(0.0f, 0.0f);
        drag = 50.0f;
        m_rigidBody.drag = (drag);
        m_rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveVector = up;
            m_rigidBody.AddForce(moveVector);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveVector = down;
            m_rigidBody.AddForce(moveVector);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector = left;
            m_rigidBody.AddForce(moveVector);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveVector = right;
            m_rigidBody.AddForce(moveVector);
        }

    }

}