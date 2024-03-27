using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour
{
    public float minMoveSpeed = 2.0f;
    public float maxMoveSpeed = 4.0f;
     float moveSpeed;
    public GameObject explosion;
    
   
    Rigidbody2D rb;
    Vector3 localScale;
    bool facingRight = true, moveAllowed = true;
    SpriteRenderer rend;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        FacingCheck();
        SetOrderLayer();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < -13f || transform.position.x > 13f)
        {
            
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (!HitsCounterControl.gameOver)
        {
            if (moveAllowed)
            {
                MoveShip();
            }else
            {
                rb.velocity = Vector2.zero;
            }
        }
            
    }

    private void MoveShip()
    {
        if (facingRight)
        {
            rb.velocity = new Vector2(moveSpeed,0); 
        }else
        {
            rb.velocity = new Vector2(-moveSpeed,0);
        }
    }

    private void FacingCheck()
    {
        if (transform.position.x < 0 )
        {
            facingRight = true;
        }else
        {
            facingRight = false;
        }
        if((facingRight && localScale.x<0) || (!facingRight && localScale.x > 0))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;  
    }

    private void SetOrderLayer()
    {
        
        if (transform.position.y == 0.25f)
            rend.sortingOrder = 4;
        if (transform.position.y == -0.5f)
            rend.sortingOrder = 6;
        if (transform.position.y == -1.25)
            rend.sortingOrder = 8;
        if (transform.position.y == -2f)
            rend.sortingOrder = 10;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals ("Rocket"))
        {
            Vector2 explpos = new Vector2 (col.gameObject.transform.position.x, col.gameObject.transform.position.y +1);
            
            if (explosion != null)
            {
                Instantiate(explosion, explpos, Quaternion.identity); 
            }
            Destroy(col.gameObject);
            moveAllowed = false;
            anim.enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
            StartCoroutine("Sinking");
        }
    }

    IEnumerator Sinking()
    {
        for (int i = 0; i <= 90; i++)
        {
            transform.rotation = Quaternion.Euler(0, 0, i);
            transform.position= new Vector2 (transform.position.x,transform.position.y - 0.05f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Destroy(gameObject);

    }

}
