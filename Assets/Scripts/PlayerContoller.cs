using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private int score;
    private Rigidbody rb;
    public float velocityUp;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
    }
    private void FixedUpdate()
    {
        SpeedProtect();  

    }
    void Update()
    {
    }



    private void OnTriggerEnter(Collider other)
    {
        // We are chancing velocty when triggired with right object. By this way we prevent many bugs.
        if (other.gameObject.CompareTag("Safe Platform"))
        {
            rb.velocity = new Vector3(0, velocityUp, 0f);
        }
        else if (other.gameObject.CompareTag("Ring")) // add score here. and destroy the ring after pass it.
        {
            score++;
            Debug.Log("Triggered with ring.Score is : "+score);
        }

    }

    void SpeedProtect()
    {
        // This method protect ball's speed while it is falling. We prevent overspeed.

        if (rb.velocity.y<= -5)
        {
            rb.velocity = new Vector3(0, -4.5f, 0);
        }
    }
}
