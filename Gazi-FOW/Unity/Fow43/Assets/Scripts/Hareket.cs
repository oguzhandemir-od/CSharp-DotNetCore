using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    int hiz = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yatay = Input.GetAxis("Horizontal")*Time.deltaTime*hiz;
        float dikey = Input.GetAxis("Vertical")*Time.deltaTime*hiz;

        //transform.Translate(new Vector3(yatay,0,dikey));

        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(yatay, 0, 0);
            //transform.Translate(new Vector3(yatay, 0, 0));
        }
    }
}
