using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutuHareket : MonoBehaviour
{
    private Rigidbody2D rbKutu;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rbKutu = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rbKutu.velocity = new Vector2(0, speed);
            //rbKutu.AddForce(Vector2.up * speed);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rbKutu.velocity = new Vector2(-speed, 0);
            //rbKutu.AddForce(Vector2.left * speed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rbKutu.velocity = new Vector2(0, -speed);
            //rbKutu.AddForce(Vector2.down * speed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rbKutu.velocity = new Vector2(speed, 0);
            //rbKutu.AddForce(Vector2.right * speed);
        }
    }
}
