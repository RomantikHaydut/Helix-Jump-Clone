using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offSet;
    public bool followPlayer;
    void Start()
    {
        player = GameObject.Find("Player");
        offSet = player.transform.position - transform.position;
        followPlayer = false;
    }

    void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (followPlayer)
        {
            transform.position = player.transform.position - offSet;
        }
        
    }
}
