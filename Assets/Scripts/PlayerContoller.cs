using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public int bestScore;
    private int passedRingWithNoTouch;
    public float velocityUp;
    public bool falling;
    public bool immortal;
    public bool destroyer;
    private bool lostPoint;

    public GameObject splash;
    public GameObject mainManager;
    private GameObject backGround;
    public Material[] materials;
    public TrailRenderer trail;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        backGround = GameObject.Find("Background");
        trail.emitting = false; // trail is off when start.
        passedRingWithNoTouch = 0;
    }
    private void FixedUpdate()
    {
        SpeedProtect();  

    }


    private void OnTriggerEnter(Collider other)
    {
        // We are chancing velocty when triggired with right object. By this way we prevent many bugs.
        if (other.gameObject.tag=="Safe Platform")
        {
            if (!lostPoint)  // Here we lose point for 1 trigger if this condition doesn't exist and if we trigger with 2 object same time we lose 2x point.
            {
                mainManager.GetComponent<MainManager>().AddScore(-1);
                rb.velocity = new Vector3(0, velocityUp, 0f);
                lostPoint = true;
            }
            falling = false;

            trail.emitting = false;
            passedRingWithNoTouch = 0;

            // spawnPos is for splash this vector3 is our triggiring position.
            Vector3 spawnPos = new Vector3(transform.position.x, other.gameObject.transform.position.y - 0.11f, transform.position.z);
            CreateSplash(spawnPos,other.gameObject);
            Falling();
        }
        else if (other.gameObject.tag=="Ring") // add score here. and destroy the ring after pass it.
        {
            passedRingWithNoTouch++;
            Falling();
            backgroundMove();
            falling = true;
            trail.emitting = true;
            mainManager.GetComponent<MainManager>().AddScore(10);
            for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                GameObject platform = other.gameObject.transform.GetChild(i).gameObject;
                Rigidbody platformRb = other.gameObject.transform.GetChild(i).gameObject.GetComponent<Rigidbody>();
                Vector3 direction = (other.gameObject.transform.GetChild(i).transform.right + new Vector3(22.5f, 0, 0)).normalized;
                DestroyRing(platform, platformRb, direction);
            }
            other.gameObject.tag = "Passed";
            Destroy(other.gameObject, 2f);
            Debug.Log("Triggered with ring");
        }
        else if (other.gameObject.tag=="Dead Area")
        {
            Debug.Log("Game Over"); // Game Over scene
            FindObjectOfType<MainManager>().gameOver = true;
        }

    }

    void SpeedProtect()
    {
        // This method protect ball's speed while it is falling. We prevent overspeed.

        if (rb.velocity.y<= -4.2f)
        {
            rb.velocity = new Vector3(0, -4.2f, 0);
        }
        // Here we set lostPoint false for can lose point.
        if (rb.velocity.y<0)
        {
            lostPoint = false;
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
            gameObject.GetComponent<Renderer>().material = materials[0];
            trail.material = gameObject.GetComponent<Renderer>().material;

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

    void DestroyRing(GameObject platform,Rigidbody platformRb,Vector3 forceWay)
    {

        // Here we will destroy the ring which we passed. We will add a force to them and make them transparent.
        platformRb.useGravity = true;
        platformRb.AddRelativeForce(forceWay*4, ForceMode.Impulse);
        platformRb.AddRelativeTorque(-transform.right*5, ForceMode.Impulse);
        platform.GetComponent<MeshRenderer>().material.color = new Color(platform.GetComponent<MeshRenderer>().material.color.r, platform.GetComponent<MeshRenderer>().material.color.g, platform.GetComponent<MeshRenderer>().material.color.b, 0.2f);

        // Here we prevent trigger function while platforms are falling.

        platform.tag = "Passed";


    }

    void backgroundMove()
    {
        backGround.transform.position = new Vector3(0,transform.position.y-10, 10);
    }
}
