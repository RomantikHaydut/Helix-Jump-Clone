using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float turnDegreePerSecond;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateThePlatform();
    }

    void RotateThePlatform()  // We rotate the cylinder here...
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontalInput * Time.deltaTime*turnDegreePerSecond, 0);
    }
}
