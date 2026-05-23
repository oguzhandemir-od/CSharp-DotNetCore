using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VidP : MonoBehaviour
{
    VideoPlayer player;
    public Sprite playSprite;
    public Sprite pauseSprite;
    public Button playpauseBtn;
    private Image buttonImage;
    public void Start()
    {
        player = GetComponent<VideoPlayer>();
        buttonImage = playpauseBtn.GetComponent<Image>();
        buttonImage.sprite = pauseSprite;
        
    }
    public void toggleBaslatDuraklat()
    {
        if (player.isPlaying)
        {
            player.Pause();
            buttonImage.sprite = playSprite;
        }
        else if (player.isPaused)
        {
            player.Play();
            buttonImage.sprite = pauseSprite;
        }

    }

    public void Durdur()
    {
        player.Stop();
    }
}
