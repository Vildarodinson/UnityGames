using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public class Boundary
    {
        public float xMin = -35;
        public float xMax = 37;
        public float zMin = -27;
        public float zMax = 27;
        //set to values of the boundary
    }
    public float speed;

    private Rigidbody rb;
    public Boundary boundary;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        SetBoundaries();
    }
    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void SetBoundaries()
    {
        //used to set limits so the player doesn't leave the screen
        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            transform.position.y,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
    }
}


