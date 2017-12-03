using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public GameObject P1WinText;
    public GameObject P2WinText;
    public GameObject drawText;
    public GameObject returnButton;
    public Slider healthBar1, healthBar2;
    public Text timerText;
    PlayerMovement Playerscrah1;
    PlayerMovement Playerscrah2;
    public int startTime;
    LevelManager Lvlmng;
    float time;
    public AudioClip WinSound;
    bool player1Wins;
    bool player2Wins;
    bool draw;
    public AudioSource P1Audio;
    public AudioSource P2Audio;
    public AudioClip P1;
    public AudioClip P2;
    bool death;
    public AudioSource Level;
    int Index;

    bool IsLoaded;
    void Start()
    {
        Lvlmng = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        Level = GameObject.Find("LevelManager").GetComponent<AudioSource>();
        player1Wins = false;
        player2Wins = false;
        draw = false;
        time = startTime;
        death = false;

        timerText.text = startTime.ToString();
        IsLoaded = false;

    }

    void Update()
    {

        if (!Lvlmng.spawn1 && !Lvlmng.spawn2 && !death)
        {
            Playerscrah1 = GameObject.Find("Player1").GetComponent<PlayerMovement>();
            Playerscrah2 = GameObject.Find("Player2").GetComponent<PlayerMovement>();
            P1Audio = GameObject.Find("Player1").GetComponent<AudioSource>();
            P2Audio = GameObject.Find("Player2").GetComponent<AudioSource>();
            healthBar1.value = Playerscrah1.Health;
            healthBar2.value = Playerscrah2.Health;

            IsLoaded = true;

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
            if (healthBar1.value > healthBar2.value && IsLoaded)
            {
                player1Wins = true;
            }
            else if (healthBar1.value < healthBar2.value && IsLoaded)
            {
                player2Wins = true;

            }
            else if (IsLoaded)
            {
                draw = true;
            }
            else
            {
                return;
            }
        }
    }
    void CheckHealth()
    {


        if (Playerscrah1.Health <= 0 && IsLoaded)
        {
            player2Wins = true;
            Debug.Log("CheckHelaat");
        }
        else if (Playerscrah2.Health <= 0 && IsLoaded)
        {
            player1Wins = true;
        }
        else if (healthBar1.value <= 0 && healthBar2.value <= 0 && IsLoaded)
        {
            draw = true;
        }

    }
    void CheckFlags()
    {
        if (player1Wins && IsLoaded)
        {
            Level.Stop();
            Playerscrah1.PlaySound();

            death = true;
            Destroy(Lvlmng.Player2);
            P1WinText.SetActive(true);
            returnButton.SetActive(true);
        }
        else if (player2Wins && IsLoaded)
        {
            Level.Stop();
            Playerscrah2.PlaySound();
            death = true;
            Destroy(Lvlmng.Player1);
            P2WinText.SetActive(true);
            returnButton.SetActive(true);
        }
        else if (draw && IsLoaded)
        {

            drawText.SetActive(true);
            returnButton.SetActive(true);
        }
    }

}
