using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject cylinder;
    public GameObject[] rings;
    public float spawnPosDistance;
    public int createdRingCount;
    void Start()
    {
        createdRingCount = 1;
        cylinder = GameObject.Find("Cylinder");
        StartCoroutine(CreateRing());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))   // Delete here...
        {
                Destroy(GameObject.FindGameObjectWithTag("Ring"));
        }
    }

    IEnumerator CreateRing()
    {
        // We are taking random index for pick random ring from rings array. 
        //And we make spawnPos (decreasing in y axis) and spawnRotations (random between 0-180 degree).
        //And we instantiate ring as a child for cylinder.
        //Our condition is activeRingCount , ring count in scene if it is less or equel 10 then our method will work every second.
        while (true)
        {
            yield return new WaitForSeconds(1);
            int activeRingCount = GameObject.FindGameObjectsWithTag("Ring").Length;
            if (activeRingCount <= 10)
            {
                int index = Random.Range(0, rings.Length);
                Vector3 spawnPos = new Vector3(0, 10 + (createdRingCount * -spawnPosDistance), 0);
                Vector3 spawnRot = new Vector3(0, Random.Range(0, 180), 0);
                GameObject ring = Instantiate(rings[index], spawnPos, Quaternion.Euler(spawnRot));
                ring.transform.parent = cylinder.transform;
                createdRingCount++;
            }
        }
    }
}
