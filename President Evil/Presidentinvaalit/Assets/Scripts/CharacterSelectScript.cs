using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScript : MonoBehaviour
{
    public string player1Selection = "", player2Selection = "";

    public float secondsBeforePlaying;

    public AudioClip[] Sounds;

    public AudioSource Thisding;
    public int CombatSceneIndex;

    bool charactersSelected = false;
    void Start()
    {
        Thisding = GameObject.Find("Sounder").GetComponent<AudioSource>();
        
    }

    void Update()
    {

        if(player1Selection != "" && player2Selection != "")
        {
            charactersSelected = true;
        }

        if (charactersSelected)
        {
            secondsBeforePlaying -= Time.deltaTime;
            if(secondsBeforePlaying <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    public void SelectKekkonen()
    {
        if(player1Selection == "")
        {
            player1Selection = "Kekkonen";
            GameObject.Find("/HahmovalikkoCanvas/Player1Select/Kekkonen").SetActive(true);
            Thisding.clip = Sounds[0];
            Thisding.Play();
        }
        else if(player1Selection != "" && player2Selection == "")
        {
            player2Selection = "Kekkonen";
            GameObject.Find("/HahmovalikkoCanvas/Player2Select/Kekkonen").SetActive(true);
            Thisding.clip = Sounds[0];
            Thisding.Play();
        }
    }
    public void SelectSale()
    {
        if (player1Selection == "")
        {
            player1Selection = "Sauli";
            GameObject.Find("/HahmovalikkoCanvas/Player1Select/Sauli").SetActive(true);
            Thisding.clip = Sounds[1];
            Thisding.Play();
        }
        else if (player1Selection != "" && player2Selection == "")
        {
            player2Selection = "Sauli";
            GameObject.Find("/HahmovalikkoCanvas/Player2Select/Sauli").SetActive(true);
            Thisding.clip = Sounds[1];
            Thisding.Play();
        }
    }
    public void SelectMarski()
    {
        if (player1Selection == "")
        {
            player1Selection = "Marski";
            GameObject.Find("/HahmovalikkoCanvas/Player1Select/Marski").SetActive(true);
            Thisding.clip = Sounds[3];
            Thisding.Play();
            
        }
        else if (player1Selection != "" && player2Selection == "")
        {
            player2Selection = "Marski";
            GameObject.Find("/HahmovalikkoCanvas/Player2Select/Marski").SetActive(true);
            Thisding.clip = Sounds[3];
            Thisding.Play();
        }
    }
    public void SelectPukki()
    {
        if (player1Selection == "")
        {
            player1Selection = "Pukki";
            GameObject.Find("/HahmovalikkoCanvas/Player1Select/Pukki").SetActive(true);
            Thisding.clip = Sounds[2];
            Thisding.Play();
        }
        else if (player1Selection != "" && player2Selection == "")
        {
            player2Selection = "Pukki";
            GameObject.Find("/HahmovalikkoCanvas/Player2Select/Pukki").SetActive(true);
            Thisding.clip = Sounds[2];
            Thisding.Play();
        }
    }
}
