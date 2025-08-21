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
    [SerializeField]LayerMask layerMask;

    private int health;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        health = 1;
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

        
        if (direction.x != 0 || direction.z != 0)
        {
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = shiftSpeed;
                anim.SetBool("runn", true);
                anim.SetBool("id", false);
                anim.SetBool("walk", false);
            }
            else 
            {
                anim.SetBool("runn", false);
                anim.SetBool("id", false);
                anim.SetBool("walk", true);
                currentSpeed = movementSpeed;
            }
        }
        if (direction.x == 0 && direction.z == 0) 
        {
            anim.SetBool("runn", false);
            anim.SetBool("id",true);
            anim.SetBool("walk", false);
        }
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E)) 
        {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit,100,layerMask)) 
            
            {
            wall w = hit.collider.GetComponentInParent<wall>();
                if (w != null && inventori.savetipe.HasFlag(worktipe.wall)) 
                {
                w.Chengrb(false);
                
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(direction * currentSpeed, ForceMode.Acceleration);
    }

    public void ChangeHealth(int count)
    {
        //вычитаем здоровье
        health -= count;
        //если здоровье меньше либо равно нулю, то...
        if (health <= 0)
        {
            anim.SetBool("die", true);
            anim.SetBool("id", false);
            anim.SetBool("walk", false);
            anim.SetBool("runn", false);
            this.enabled = false;
        }
    }


}
