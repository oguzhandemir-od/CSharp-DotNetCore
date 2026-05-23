using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroHareket : MonoBehaviour
{
    public float hizKatsayisi = 5;
    bool sagaBakiyor;
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        sagaBakiyor = true;
    }

    // Update is called once per frame
    void Update()
    {
        float yatay = Input.GetAxis("Horizontal");
        transform.position += new Vector3(yatay * hizKatsayisi * Time.deltaTime, 0, 0);

        float dikey = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, dikey * hizKatsayisi * Time.deltaTime, 0);

        if ((yatay < 0) && sagaBakiyor == true)
        {
            Dondur();
        }

        if ((yatay > 0) && sagaBakiyor == false)
        {
            Dondur();
        }
    }

    void Dondur()
    {
        sagaBakiyor = (!sagaBakiyor);
        transform.Rotate(new Vector3(0, 180, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Spike"&&health>0)
        {
            health -= 10;
        }

        if(collision.tag=="Kristaller"&&health<100)
        {
            health += 10;
            Destroy(collision.gameObject);
        }
    }
}
