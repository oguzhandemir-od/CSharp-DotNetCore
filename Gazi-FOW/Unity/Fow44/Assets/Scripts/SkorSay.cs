using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkorSay : MonoBehaviour
{
    public TMP_Text sayac;
    int skor = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Skor()
    {
        skor++;
        sayac.text=skor.ToString();
        
    }
}
