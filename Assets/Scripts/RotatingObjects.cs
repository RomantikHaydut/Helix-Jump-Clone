using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObjects : MonoBehaviour
{
    bool turningRight;
    void Start()
    {
        StartCoroutine(Turn());
        InvokeRepeating("TurnBack", 1f, 1f);
    }


    IEnumerator Turn()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (turningRight)
            {
                transform.Rotate(transform.up * 83f * Time.deltaTime);
            }
            else
            {
                transform.Rotate(transform.up * -83f * Time.deltaTime);
            }

        }
    }

    void TurnBack()
    {
        turningRight = !turningRight;
    }
}
