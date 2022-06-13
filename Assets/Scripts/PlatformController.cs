using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    void FixedUpdate()
    {
        RotateThePlatform();
    }

    void RotateThePlatform()  // We rotate the cylinder here...
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontalInput * Time.deltaTime*(GameManager.activeSensitivity), 0);
    }
}
