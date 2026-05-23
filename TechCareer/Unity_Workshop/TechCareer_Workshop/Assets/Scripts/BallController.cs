using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Dynamic;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float topHizi = 3f;
    int skorOyuncuBir;
    int skorOyuncuIki;
    public TextMeshProUGUI oyuncuBirSkor;
    public TextMeshProUGUI oyuncuIkiSkor;
    public GameObject gameOver;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        BallRandom();
        skorOyuncuBir = 0;
        skorOyuncuIki = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameOver.SetActive(false);
            ResetGame();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag=="SolDuvar")
    //    {
    //        skorOyuncuIki++;
    //        oyuncuIkiSkor.text = skorOyuncuIki.ToString();
    //    }
    //    if (collision.gameObject.tag == "SagDuvar")
    //    {
    //        skorOyuncuBir++;
    //        oyuncuBirSkor.text = skorOyuncuBir.ToString();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SagSinir")
        {
            skorOyuncuBir++;
            oyuncuBirSkor.text = skorOyuncuBir.ToString();
        }
        if (collision.tag == "SolSinir")
        {
            skorOyuncuIki++;
            oyuncuIkiSkor.text = skorOyuncuIki.ToString();
        }
        transform.position = spawnPoint.position;
        GameOver();
        BallRandom();

    }

    //void RespawnBall()
    //{

    //    Invoke("RespawnBall", 1f);
    //}

    void BallRandom()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x * topHizi, y * topHizi);
    }
    void ResetGame()
    {
        gameObject.SetActive(true);
        transform.position = spawnPoint.position;
        BallRandom();
        skorOyuncuBir = 0;
        skorOyuncuIki = 0;
        oyuncuBirSkor.text = "0";
        oyuncuIkiSkor.text = "0";
    }

    void GameOver()
    {
        if (skorOyuncuBir == 5)
        {
            transform.position = spawnPoint.position;
            gameObject.SetActive(false);
            gameOver.SetActive(true);
        }
        if (skorOyuncuIki == 5)
        {
            transform.position = spawnPoint.position;
            gameObject.SetActive(false);
            gameOver.SetActive(true);
        }
    }
}
