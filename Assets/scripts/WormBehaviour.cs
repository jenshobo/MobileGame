using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBehaviour : MonoBehaviour
{
    public GameObject wormPart;
    public float spawnRate = 7.5f;

    public float movementSpeed = 2.5f;

    private int spawnAmount = 10;
    private float nextTimeToSpawn = 0f;

    void Start()
    {
        wormPart.transform.position = transform.position;
    }

    public void SpawnWormPart()
    {
        if (spawnAmount >= 1)
        {
            Instantiate(wormPart);

            spawnAmount--;
        }
    }

    public void FixedUpdate()
    {
        if (transform.tag == "WormStarter" && Time.time >= nextTimeToSpawn && spawnAmount >= 1)
        {
            nextTimeToSpawn = Time.time + 1f / spawnRate;
            Instantiate(wormPart);
            spawnAmount--;

        }
        if (transform.tag == "WormPart")
        {
            Destroy(gameObject, 5);
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        }

        if (transform.tag == "WormStarter" && spawnAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateRotation(int rotation)
    {
        wormPart.transform.Rotate(new Vector3(0, 0, rotation));
    }
}