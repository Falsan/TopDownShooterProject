using UnityEngine;
using System.Collections;

public class PlayerFireScript : MonoBehaviour {

    [SerializeField]
    GameObject bulletRef;

    enum fireAngles
    {
        up = 0,
        left = 1,
        right = 2
    }
    int m_fireAngle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.W))
        {
            m_fireAngle = (int)fireAngles.up;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            m_fireAngle = (int)fireAngles.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            m_fireAngle = (int)fireAngles.right;
        }
        
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            //pew
            Instantiate(bulletRef).
                GetComponent<BulletScript>().
                setDirectionAndPosition(gameObject, m_fireAngle);
        }
    }
}
