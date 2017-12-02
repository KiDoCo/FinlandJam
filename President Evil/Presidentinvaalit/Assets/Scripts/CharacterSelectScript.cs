using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScript : MonoBehaviour
{
    public string player1Selection = "", player2Selection = "";

    public float secondsBeforePlaying;

    public int CombatSceneIndex;

    bool charactersSelected = false;

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
        }
        else if(player1Selection != "" && player2Selection == "")
        {
            player2Selection = "Kekkonen";
            GameObject.Find("/HahmovalikkoCanvas/Player2Select/Kekkonen").SetActive(true);
        }
    }
    public void SelectSale()
    {
        if (player1Selection == "")
        {
            player1Selection = "Sauli";
            GameObject.Find("/HahmovalikkoCanvas/Player1Select/Sauli").SetActive(true);
        }
        else if (player1Selection != "" && player2Selection == "")
        {
            player2Selection = "Sauli";
            GameObject.Find("/HahmovalikkoCanvas/Player2Select/Sauli").SetActive(true);
        }
    }
    public void SelectMarski()
    {
        if (player1Selection == "")
        {
            player1Selection = "Marski";
            GameObject.Find("/HahmovalikkoCanvas/Player1Select/Marski").SetActive(true);
        }
        else if (player1Selection != "" && player2Selection == "")
        {
            player2Selection = "Marski";
            GameObject.Find("/HahmovalikkoCanvas/Player2Select/Marski").SetActive(true);
        }
    }
    public void SelectPukki()
    {
        if (player1Selection == "")
        {
            player1Selection = "Pukki";
            GameObject.Find("/HahmovalikkoCanvas/Player1Select/Pukki").SetActive(true);
        }
        else if (player1Selection != "" && player2Selection == "")
        {
            player2Selection = "Pukki";
            GameObject.Find("/HahmovalikkoCanvas/Player2Select/Pukki").SetActive(true);
        }
    }
}
