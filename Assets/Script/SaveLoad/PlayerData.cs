using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public float[] position;

    public PlayerData(FirstPersonController location)
    {
        position = new float[3];
        position[0] = location.transform.position.x;
        position[1] = location.transform.position.y;
        position[2] = location.transform.position.z;
    }

}


