using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectals : MonoBehaviour
{
    public float movementSpeed;
    public float offset;

    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;

    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        targetPos = Player.transform.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        Destroy(gameObject, 15f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
    }
}