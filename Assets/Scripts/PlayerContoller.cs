using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private int score;
    public float velocityUp;

    public GameObject splash;
    private CameraController cameraController;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraController = Camera.main.GetComponent<CameraController>();
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
            cameraController.followPlayer = false;

            rb.velocity = new Vector3(0, velocityUp, 0f);

            // spawnPos is for splash this vector3 is our triggiring position.
            Vector3 spawnPos = new Vector3(transform.position.x, other.gameObject.transform.position.y - 0.11f, transform.position.z);
            CreateSplash(spawnPos,other.gameObject);
        }
        else if (other.gameObject.CompareTag("Ring")) // add score here. and destroy the ring after pass it.
        {
            cameraController.followPlayer = true;
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

    void CreateSplash(Vector3 spawnPos,GameObject parent) // We call this method in trigger method so spawnPos and parent should come from there.
    {
        // This method creates splash sprites when we touch the platform.
        GameObject splashClone=Instantiate(splash, spawnPos, splash.transform.rotation);
        splashClone.GetComponent<Renderer>().material.color = Color.yellow;
        splashClone.transform.parent = parent.transform;
        Destroy(splashClone, 4f);
    }
}
