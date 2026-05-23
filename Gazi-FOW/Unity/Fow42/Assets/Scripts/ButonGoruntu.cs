using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ButonGoruntu : MonoBehaviour
{
    VideoPlayer player;
    public Sprite playSprite;
    public Sprite pauseSprite;
    private Image buttonImage;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = playSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPlaying)
        {
            buttonImage.sprite = pauseSprite;
        }
        else if (player.isPaused)
        {
            buttonImage.sprite = playSprite;
        }
    }
}
