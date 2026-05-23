using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform atesNoktasi;
    public GameObject bullet;
    public float fireRate = 3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AtesEt", 0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AtesEt()
    {
        Instantiate(bullet, atesNoktasi.position, atesNoktasi.rotation);
    }
}
