using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offSet;
    void Start()
    {
        player = GameObject.Find("Player");
        offSet = player.transform.position - transform.position;
    }

    void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (player.GetComponent<PlayerContoller>().falling)
        {
            transform.position = player.transform.position - offSet;
        }
        
    }
}
