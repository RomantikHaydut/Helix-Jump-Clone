using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody rb;
    public float velocityUp;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

    }
}
