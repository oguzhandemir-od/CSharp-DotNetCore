using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etkilesim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ON TRIGGER ENTER");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("ON TRIGGER STAY");

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ON TRIGGER EXIT");

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ON COLLISION ENTER");
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("ON COLLISION STAY");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("ON COLLISION EXIT");

    }
}
