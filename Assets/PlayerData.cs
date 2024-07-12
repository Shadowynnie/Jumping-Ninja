using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int level;
    public int coins;
    public int shurikens;
    public float[] position;
    public float[] checkPointPosition;


    public PlayerData(Player player) 
    {
        health = player.maxHealth;
        level = player.level;
        coins = player.coinCount;
        shurikens = player.shurikenCount;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        checkPointPosition = player.GetCheckPointPos();

    }
}
