using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float jumpForce = 10f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
