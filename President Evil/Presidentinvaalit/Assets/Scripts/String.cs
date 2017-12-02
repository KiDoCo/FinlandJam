using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class String : MonoBehaviour
{
    CharacterSelectScript Selection;
    public string PlayerSelection1, PlayerSelection2;
    void Start()
    {
        Selection = GameObject.Find("HahmovalikkoCanvas").GetComponent<CharacterSelectScript>();
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        PlayerSelection1 = Selection.player1Selection;
        PlayerSelection2 = Selection.player2Selection;

        //if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        //{
        //    Destroy(this);
        //}
    }
}
