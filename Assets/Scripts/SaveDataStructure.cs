using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


[System.Serializable] public class SaveDataStructure
{
    public int health;
    public int attack;
    public float speed;
    public int score;

    public SaveDataStructure (PlayerManager player , PlayerCombact playercombact, ScoreScript scorescript )

    {
        health = player.maxHealth;
        speed = player.speed;
        score = scorescript.score;
        attack = playercombact.attackDamage;

    }

}
