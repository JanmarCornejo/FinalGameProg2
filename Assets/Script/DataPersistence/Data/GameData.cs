using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{

    public Vector3 playerPosition;

    public SerialzableDictionary<string, bool> KeyCardsCollected;

    


    public GameData()
    {
        playerPosition= Vector3.zero;
        KeyCardsCollected= new SerialzableDictionary<string, bool>();
        
    }
}
    