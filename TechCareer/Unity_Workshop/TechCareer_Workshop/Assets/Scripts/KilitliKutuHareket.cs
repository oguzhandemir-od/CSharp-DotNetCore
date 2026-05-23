using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilitliKutuHareket : MonoBehaviour
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

            rbKutu.AddForce(Vector2.up * speed);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            rbKutu.AddForce(Vector2.left * speed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            rbKutu.AddForce(Vector2.down * speed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            rbKutu.AddForce(Vector2.right * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platformlar")
        {
            Destroy(gameObject);
        }
    }
}
