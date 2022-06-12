using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject cylinder;
    public GameObject cylinderPrefab;
    public GameObject[] rings;
    public float spawnPosDistance; 
    public int createdRingCount;
    public int createdCylinderCount;
    void Start()
    {
        createdRingCount = 1;
        createdCylinderCount = 1;
        cylinder = GameObject.Find("Cylinder");
        StartCoroutine(CreateRing());
        StartCoroutine(CreateCylinder());
    }

    void Update()
    {
        
    }

    IEnumerator CreateRing()
    {
        // We are taking random index for pick random ring from rings array. 
        //And we make spawnPos (decreasing in y axis) and spawnRotations (random between 0-180 degree).
        //And we instantiate ring as a child for cylinder.
        //Our condition is activeRingCount , ring count in scene if it is less or equel 10 then our method will work every second.
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            int activeRingCount = GameObject.FindGameObjectsWithTag("Ring").Length;
            if (activeRingCount <= 15)
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

    IEnumerator CreateCylinder()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int activeCylinderCount = GameObject.FindGameObjectsWithTag("Cylinder").Length;
            if (activeCylinderCount<=4)
            {
                Vector3 cylinderSpawnPos = new Vector3(0, -60 * createdCylinderCount, 0);
                Instantiate(cylinderPrefab, cylinderSpawnPos, cylinderPrefab.transform.rotation);
                createdCylinderCount++;
            }
            
        }
        
    }
}
