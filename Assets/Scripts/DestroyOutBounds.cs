using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{
    private GameObject player;
    private float distance;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    
    void Update()
    {

        // Here we take spawning cylinders position and if distance between them and player bigger then 80 we will destroy them.
        distance =  transform.position.y -player.transform.position.y ;
        if (distance>=80)
        {
            Destroy(gameObject);
        }
    }
}
