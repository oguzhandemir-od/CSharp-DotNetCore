using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronotHareket : MonoBehaviour
{
    public float hizKatsayisi;
    public int kristalSayisi;
    public int saglik = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal");
        transform.position += new Vector3(yatay * hizKatsayisi * Time.deltaTime, 0, 0);
        //Debug.Log(yatay);

        float dikey = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, dikey * hizKatsayisi * Time.deltaTime, 0);
    }

    private void LateUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Çarpýþma Gerçekleþti!!!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Kristaller" && saglik < 100)
        {
            kristalSayisi++;
            saglik++;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Spike" && saglik > 0)
        {
            saglik--;
            Destroy(gameObject);
        }
    }

}
