using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep : MonoBehaviour
{
    public Transform atesNoktasi;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            AtesEt();
        }
    }

    void AtesEt()
    {
        Instantiate(bullet,atesNoktasi.position,atesNoktasi.rotation);
    }
}
