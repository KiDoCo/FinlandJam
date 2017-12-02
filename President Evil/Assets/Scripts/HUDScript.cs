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

    public int startTime, startHealths;

    float time;

    bool player1Wins = false;
    bool player2Wins = false;
    bool draw = false;

    void Start()
    {
        healthBar1.value = startHealths;
        healthBar2.value = startHealths;

        time = startTime;
        timerText.text = startTime.ToString();
    }

    void Update()
    {
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
            winnerText.text = "PLAYER 1 WINS!";
            returnButton.SetActive(true);
        }
        else if (player2Wins)
        {
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
