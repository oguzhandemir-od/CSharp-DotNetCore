using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanDonus : MonoBehaviour
{
    bool sagaBakiyor;
    public float hizKatsayisi = 3;
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
}
