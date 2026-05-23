using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YaziAyar : MonoBehaviour
{
    public TMP_Text cikti;
    public TMP_InputField girdi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cikti.text = girdi.text;
    }
}
