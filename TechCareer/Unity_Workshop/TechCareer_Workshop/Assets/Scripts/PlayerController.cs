using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool oyuncuBirMi;
    public Rigidbody2D rb;
    public float oyuncuHizi = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(oyuncuBirMi)
        {
            rb.velocity = Vector2.up * Input.GetAxisRaw("Vertical") * oyuncuHizi;
        }
        else
        {
            rb.velocity = Vector2.up * Input.GetAxisRaw("Vertical2") * oyuncuHizi;

        }
    }
}
