using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Transform PL1Spawn;
    public Transform PL2Spawn;
    public GameObject PL1;
    public GameObject PL2;
    public GameObject[] PlayerPrefabs;
    public String SelectObj;
    string PlayerSelect;
    public GameObject Player1;
    public GameObject Player2;
    public bool spawn1, spawn2;
    public int SelectionSound;
    public int SelectionSound2;

    CharacterSelectScript Select;
    private void Start()
    {
        PL1Spawn = GameObject.Find("SpawnpointPL1").GetComponent<Transform>();
        PL2Spawn = GameObject.Find("SpawnpointPL2").GetComponent<Transform>();
        SelectObj = GameObject.Find("PlayerSelection").GetComponent<String>();
        spawn1 = true;
        spawn2 = true;
        switch(SelectObj.PlayerSelection1)
        {
            case "Kekkonen":
                PL1 = PlayerPrefabs[0];
                SelectionSound = 0;
                break;
            case "Sauli":
                PL1 = PlayerPrefabs[1];
                SelectionSound = 3;
                break;
            case "Marski":
                PL1 = PlayerPrefabs[2];
                SelectionSound = 1;
                break;
            case "Pukki":
                PL1 = PlayerPrefabs[3];
                SelectionSound = 2;
                break;
            default:
                Debug.Log("Error!!");
                break;
        }
        switch(SelectObj.PlayerSelection2)
        {
            case "Kekkonen":
                PL2 = PlayerPrefabs[0];
                SelectionSound2 = 0;
                break;
            case "Sauli":
                PL2 = PlayerPrefabs[1];
                SelectionSound2 = 1;
                break;
            case "Marski":
                PL2 = PlayerPrefabs[2];
                SelectionSound2 = 2;
                break;
            case "Pukki":
                PL2 = PlayerPrefabs[3];
                SelectionSound2 = 3;
                break;
            default:
                Debug.Log("Error!!PL2");
                break;
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       else if (spawn1)
        {
           Player1 = Instantiate(PL1, PL1Spawn.position, Quaternion.identity, PL1Spawn);
            Player1.name = "Player1";
            
            spawn1 = false;
        }

        if (spawn2)
        {
           Player2 = Instantiate(PL2, PL2Spawn.position, Quaternion.identity, PL2Spawn);
            Player2.name = "Player2";
            
            spawn2 = false;
            
        }
    }
    public void ResetAll()
    {
        BroadcastMessage("Reset");

    }

}
