using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private int score;
    public int bestScore;
    private int passedRingWithNoTouch;
    public float velocityUp;
    public bool falling;
    public bool immortal;
    public bool destroyer;

    public GameObject splash;
    public Material[] materials;
    public TrailRenderer trail;
    private Rigidbody rb;
    void Start()
    {
        trail.emitting = false; // trail is off when start.
            
        rb = GetComponent<Rigidbody>();
        score = 0;
        passedRingWithNoTouch = 0;
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
            score--;
            falling = false;
            trail.emitting = false;
            passedRingWithNoTouch = 0;
            rb.velocity = new Vector3(0, velocityUp, 0f);

            // spawnPos is for splash this vector3 is our triggiring position.
            Vector3 spawnPos = new Vector3(transform.position.x, other.gameObject.transform.position.y - 0.11f, transform.position.z);
            CreateSplash(spawnPos,other.gameObject);
            Falling();
        }
        else if (other.gameObject.CompareTag("Ring")) // add score here. and destroy the ring after pass it.
        {
            passedRingWithNoTouch++;
            Falling();
            falling = true;
            trail.emitting = true;
            GetScore();
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

    void CreateSplash(Vector3 spawnPos,GameObject parent) // We call this method in trigger method so spawnPos and parent should come from there.
    {
        // This method creates splash sprites when we touch the platform.
        GameObject splashClone=Instantiate(splash, spawnPos, splash.transform.rotation);
        splashClone.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
        splashClone.transform.parent = parent.transform;
        Destroy(splashClone, 4f);
    }

    void Falling()  
    {
        // This method we give abilities the player like immortal and destroyer. According to passed ring with no touch count. 
        // And we change player's material and trail's material here too.

        if (passedRingWithNoTouch == 0)
        {
            immortal = false; destroyer = false;
            trail.material = gameObject.GetComponent<Renderer>().material;
            gameObject.GetComponent<Renderer>().material = materials[0];

        }
        else if (passedRingWithNoTouch >= 2 && passedRingWithNoTouch < 3)
        {
            immortal = true;
            gameObject.GetComponent<Renderer>().material = materials[1];
            trail.material = gameObject.GetComponent<Renderer>().material;

        }
        else if (passedRingWithNoTouch>=3)
        {
            destroyer = true;
            gameObject.GetComponent<Renderer>().material = materials[2];
            trail.material = gameObject.GetComponent<Renderer>().material;

        }

    }

    void GetScore()
    {
        score+=10;
        if (score>=bestScore)
        {
            bestScore = score;
        }
    }
}
