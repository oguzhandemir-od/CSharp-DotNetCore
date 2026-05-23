using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AstronotDonme : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float turningSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up*movementSpeed*Time.deltaTime);

        if(Input.GetKey(KeyCode.D))
        {            
            transform.Rotate(Vector3.forward*-turningSpeed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turningSpeed * Time.deltaTime);
        }
    }
}
