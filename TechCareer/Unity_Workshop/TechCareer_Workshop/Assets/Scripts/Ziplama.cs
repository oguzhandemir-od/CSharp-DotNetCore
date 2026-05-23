using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ziplama : MonoBehaviour
{
    public LayerMask layer;
    public bool yerdeMi;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D carptiMi = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, layer);
        if (carptiMi.collider != null)
        { // Yerdeyiz
            yerdeMi = true;
        }
        else
        { // Havadayýz
            yerdeMi = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && yerdeMi == true)
        {
            rb.velocity += new Vector2(0, 5f);
        }
    }
}
