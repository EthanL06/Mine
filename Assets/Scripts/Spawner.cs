using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        // Get all children with the tag "Spawn"
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("WaitAndSpawn");
    }

    IEnumerator WaitAndSpawn()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(1);
        // Spawn a new object
        Spawn();
    }

    void Spawn()
    {
        // Get a random spawn point
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // Spawn a new object at the spawn point
        Instantiate(Resources.Load("Food icon Pack/acorn"), spawnPoint.transform.position, Quaternion.identity);
    }
}
