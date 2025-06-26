using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plaer : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    float currentSpeed;
    Rigidbody rb;
    Vector3 direction;
    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = movementSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = shiftSpeed;


        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            
            currentSpeed = movementSpeed;
        }
        if (direction.x != 0 || direction.z != 0)
        {
            anim.SetBool("runn", true);
            anim.SetBool("id", false);
        }
        if (direction.x == 0 && direction.z == 0) 
        {
            anim.SetBool("runn", false);
            anim.SetBool("id",true);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    
}
