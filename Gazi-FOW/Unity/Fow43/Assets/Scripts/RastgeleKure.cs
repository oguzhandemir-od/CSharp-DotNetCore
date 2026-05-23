using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RastgeleKure : MonoBehaviour
{
    GameObject kure;
    public int kureSayisi;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < kureSayisi; i++)
        {
            kure = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            kure.transform.position = new Vector3(Random.Range(-30, 30), Random.Range(1, 30), Random.Range(-30, 30));
            kure.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
