using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    Vector2 pos;
    public float direction = 1f; 
    float frequancy;
    float magnitude;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        frequancy = Random.Range(1.9f, 2.1f);
        magnitude = Random.Range(0.07f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        pos.x = Mathf.Sin (Time.time * frequancy) * magnitude * direction;
        transform.position = pos;
    }
}
