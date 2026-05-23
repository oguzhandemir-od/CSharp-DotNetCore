using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesCal : MonoBehaviour
{
    public GameObject ammo;

    public AudioClip mermiSesi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject mermi = Instantiate(ammo);
            mermi.name = "mermi";
            AudioSource atesSesi = mermi.AddComponent<AudioSource>();
            atesSesi.clip = mermiSesi;
            atesSesi.Play();

        }
        
    }
}
