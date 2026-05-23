using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaliLerp : MonoBehaviour
{
    private Vector3 bitisKonumu = new Vector3(-5, -2, 0);
    private Vector3 baslangicKonumu;
    private float istenilenSure = 3f;
    private float gecenSure;
    // Start is called before the first frame update
    void Start()
    {
        baslangicKonumu = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gecenSure += Time.deltaTime;
        float tamamlananYuzde = gecenSure / istenilenSure;
        //transform.position = Vector3.Lerp(baslangicKonumu, bitisKonumu, tamamlananYuzde);
        //transform.position = Vector3.Lerp(baslangicKonumu, bitisKonumu, Time.deltaTime);
        transform.position = Vector3.Lerp(baslangicKonumu, bitisKonumu, Mathf.SmoothStep(0, 1, tamamlananYuzde));


    }
}
