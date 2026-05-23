using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHareket : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(0,speed);
        }
        else
        {
            rb.velocity = new Vector2(0,-speed);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 9f &&
            currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 9f &&
            currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }
}
