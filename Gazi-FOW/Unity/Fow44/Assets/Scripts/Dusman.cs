using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dusman : MonoBehaviour
{
    public GameObject robot;
    public int robotSayisi;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < robotSayisi; i++)
        {
            robot = GameObject.Instantiate(robot);
            robot.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(1, 1), Random.Range(-10, 10));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            
        }
    }
    
}
