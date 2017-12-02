using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public GameObject returnButton;
    public Slider healthBar1, healthBar2;
    public Text timerText, winnerText;
    PlayerMovement Playerscrah1;
    PlayerMovement Playerscrah2;
    public int startTime;
    LevelManager Lvlmng;
    float time;
    public AudioClip WinSound;
    bool player1Wins = false;
    bool player2Wins = false;
    bool draw = false;
    public AudioSource audio;
    public AudioSource Level;
    public AudioClip[] Sounds;
    int Index;
    bool FoundPlayer = true;
    void Start()
    {
        Lvlmng = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        Level = GameObject.Find("LevelManager").GetComponent<AudioSource>();
        time = startTime;
        timerText.text = startTime.ToString();
        
    }

    void Update()
    {
        
        if (!Lvlmng.spawn1 && !Lvlmng.spawn2)
        {
            Playerscrah1 = GameObject.Find("Player1").GetComponent<PlayerMovement>();
            Playerscrah2 = GameObject.Find("Player2").GetComponent<PlayerMovement>();
            healthBar1.value = Playerscrah1.Health;
            healthBar2.value = Playerscrah2.Health;
           
        }
        if (FoundPlayer)
        {
            FoundPlayer = false;
        }
        RoundTimer();
        CheckHealth();
        CheckFlags();
    }
    void RoundTimer()
    {
        //ROUND TIMER
        //COUNTDOWN
        time -= Time.deltaTime;
        if (time < 10)
        {
            timerText.text = ("0" + (time).ToString());
        }
        else
        {
            timerText.text = (time).ToString();
        }
        //ROUND END
        if (time <= 0)
        {
            timerText.text = "00";
            if (healthBar1.value > healthBar2.value)
            {
                player1Wins = true;
            }
            else if (healthBar1.value < healthBar2.value)
            {
                player2Wins = true;
            }
            else
            {
                draw = true;
            }
        }
    }
    void CheckHealth()
    {
        if (healthBar1.value <= 0)
        {
            player2Wins = true;
        }
        else if (healthBar2.value <= 0)
        {
            player1Wins = true;
        }
        else if (healthBar1.value <= 0 && healthBar2.value <= 0)
        {
            draw = true;
        }
    }
    void CheckFlags()
    {
        if (player1Wins)
        {
            Level.Stop();
            Index = Lvlmng.SelectionSound;
            Debug.Log(Index);
            audio.clip = Sounds[Index];
            audio.Play();
            winnerText.text = "PLAYER 1 WINS!";
            returnButton.SetActive(true);
        }
        else if (player2Wins)
        {
            Level.Stop();
            Debug.Log(Index);
            Index = Lvlmng.SelectionSound2;
            audio.clip = Sounds[Index];
            audio.Play();
            winnerText.text = "PLAYER 2 WINS!";
            returnButton.SetActive(true);
        }
        else if (draw)
        {
            
            winnerText.text = "ROUND IS DRAW!";
            returnButton.SetActive(true);
        }
    }
    
}
