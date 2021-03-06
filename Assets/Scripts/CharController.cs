using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 7f;
    [SerializeField]
    float jumpForce = 5f;
   

    Vector3 forward, right, up;
   
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        up = Vector3.up;
        
        
    }

    void Update()
    {
        if(Input.anyKey)

        Move();
        
    }
   void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
        Vector3 jumpMovement = up * jumpForce * Time.deltaTime * Input.GetAxis("Jump");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement + jumpMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
        transform.position += jumpMovement;
    }
}
