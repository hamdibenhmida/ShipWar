using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float moveSpeed = 2f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 7) // y > 7 means that the rocket outside of the scene on top 
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0,moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CivilianBoat"))
        {
            HitsCounterControl.gameOver = true;
        }
        else if (collision.CompareTag("EnemyBoats"))
        {
            HitsCounterControl.hitsCounter += 1; 
        }

    }
}
