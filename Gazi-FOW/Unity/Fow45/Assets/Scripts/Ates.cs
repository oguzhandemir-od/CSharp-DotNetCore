using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ates : MonoBehaviour
{
    public GameObject ammo;
    public int atesHizi;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject mermi = Instantiate(ammo);
            mermi.name = "mermi";
            Rigidbody rb = mermi.AddComponent<Rigidbody>();
            rb.AddForce(transform.forward * atesHizi, ForceMode.Impulse);
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            mermi.transform.position = gameObject.transform.position;
            mermi.transform.rotation = gameObject.transform.rotation;
        }
    }
}
