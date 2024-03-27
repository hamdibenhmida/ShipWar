using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    float dirX;
    Rigidbody2D rb;
    float nextFire; //used for cooldown the fire 

    public GameObject rocket;
    public float moveSpeed = 5f;
    public float fireRate = 2f; // change this value to change the cooldown (with seconds)

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");

        if (!HitsCounterControl.gameOver)
        {
            

            if (Input.GetButtonDown("Fire1"))
            {
                LaunchRocket();
            }

            

        }
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9, 9), transform.position.y);// this line force the base to stay inside the scene (y=-9 is the edge on the left and y=9 is the edge on the right)
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed,0); 
    }
    private void LaunchRocket()
    {
        
        if (Time.time >= nextFire) 
        {
            Instantiate (rocket,transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
