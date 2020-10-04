using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public GameObject projectal;
    public GameObject wormStart;
    public float randomSpawnXMin;
    public float randomSpawnXMax;
    public float randomSpawnYMin;
    public float randomSpawnYMax;

    public float wormStartPositionTop;
    public float wormStartPositionBothem;

    private float nextTimeToFireSpike = 0f;
    private float fireRateSpike;

    private float nextTimeToFireWorm = 0f;
    private float fireRateWorm;
    private int wormPartRotation;
    private bool wormSpawnState = false;
    private Vector3 wormPosition;

    void Update()
    {
        if (Time.time >= nextTimeToFireSpike)
        {
            fireRateSpike = Random.Range(0.5f, 1f);
            nextTimeToFireSpike = Time.time + 1f / fireRateSpike;
            projectal.transform.position = new Vector3(Random.Range(randomSpawnXMin, randomSpawnXMax), Random.Range(randomSpawnYMin, randomSpawnYMax), 0f);

            Instantiate(projectal);
        }

        if (Time.time >= nextTimeToFireWorm && wormSpawnState)
        {
            fireRateWorm = Random.Range(0.05f, 0.1f);
            nextTimeToFireWorm = Time.time + 1f / fireRateWorm;
            wormStart.transform.position = new Vector3(Random.Range(randomSpawnXMin, randomSpawnXMax), Random.Range(randomSpawnYMin, randomSpawnYMax), 0f);

            if (transform.tag == "topSpawner")
            {
                wormPartRotation = 0;
                WormBehaviour worm = wormStart.transform.GetComponent<WormBehaviour>();
                worm.UpdateRotation(wormPartRotation);
                wormPosition = wormStart.transform.position;
                wormPosition.y = wormStartPositionTop;
                Instantiate(wormStart);
            }

            if (transform.tag == "bothemSpawner")
            {
                wormPartRotation = 180;
                WormBehaviour worm = wormStart.transform.GetComponent<WormBehaviour>();
                worm.UpdateRotation(wormPartRotation);
                wormPosition = wormStart.transform.position;
                wormPosition.y = wormStartPositionBothem;
                Instantiate(wormStart);
            }
            else
                return;
        }
    }

    public void UpdateState(bool wormState)
    {
        wormSpawnState = wormState;
    }
}