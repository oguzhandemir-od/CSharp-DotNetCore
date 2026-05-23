using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olustur : MonoBehaviour
{
    GameObject kup;
    // Start is called before the first frame update
    void Start()
    {
        kup=GameObject.CreatePrimitive(PrimitiveType.Cube);
        kup.name = "Kup1";
        kup.transform.position = new Vector3(2, 2, 2);
        Rigidbody rb = kup.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go2=GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Rigidbody rb=go2.AddComponent<Rigidbody>();
            kup.transform.position = new Vector3(2, 2, 2);
        }
    }
}
