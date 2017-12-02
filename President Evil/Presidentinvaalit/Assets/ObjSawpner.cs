using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSawpner : MonoBehaviour
{
    public Transform[] Spawns;
    
    int Index;
    bool Spawned;
    public GameObject Hela;
    void Start()
    {
        Spawned = true;
    }
    
    void Update()
    {
        Index = Random.Range(0, 4);
        if (Spawned)
        {
            Instantiate(Hela, Spawns[Index].position, Quaternion.identity, Spawns[Index]);
            Spawned = false;
            Invoke("ResetTime", 5.0f);
        }
        else
        {
            return;
        }
    }
    void ResetTime()
    {
        Spawned = true;
    }
}
