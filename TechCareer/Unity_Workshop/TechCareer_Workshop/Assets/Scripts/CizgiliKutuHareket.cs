using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CizgiliKutuHareket : MonoBehaviour
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
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rbKutu.velocity = new Vector2(-speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rbKutu.velocity = new Vector2(0, -speed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rbKutu.velocity = new Vector2(speed, 0);
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
