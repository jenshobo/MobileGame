using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehaviour : MonoBehaviour
{
    private float sizeX = 0f;
    private float sizeY = 0f;

    private bool keepGrowing = true;

    void Start()
    {
        Destroy(this.gameObject, 15);
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward);

        if (keepGrowing)
        {
            sizeX = sizeX + 0.01f;
            sizeY = sizeY + 0.01f;
            transform.localScale = new Vector2(sizeX, sizeY);
        }

        if (sizeX >= 5)
            keepGrowing = false;
    }
}