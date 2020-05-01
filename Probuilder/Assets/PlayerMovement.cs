using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float gravity = -10f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounden;

    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounden = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounden && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

       
            Vector3 move = transform.right * x + transform.forward * z;


            controller.Move(move * speed * Time.deltaTime);
        

        

        if(Input.GetKeyDown(KeyCode.Space) && isGrounden)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); 
    }
}
