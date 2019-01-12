using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float jumpSpeed = 50f;
    public float distToGround = 4f;
    public Rigidbody rb;
    private bool jump = false;
    private float jumpCounter = 0;
    Vector3 forward, right;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        InvokeRepeating("Jump", 0.5f, 3f);
    }

    void FixedUpdate()
    {
        //if(Input.GetButtonDown("Jump"))
        //{
        //    StartCoroutine(Jump());
        //}
        if(Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKeys"), 0, Input.GetAxis("VerticalKeys"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKeys");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKeys");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    void Jump()
    {
        //float originalHeight = transform.position.y;
        //jump = true;
        //yield return null;

        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

        //while(transform.position.y > originalHeight) {
        //    yield return null;
        //}

        ////jump = false;

        //yield return null;
    }
}
