using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gameplay Parameters", menuName = "Gameplay/Gameplay parameters")]
public class GameplayParameters : ScriptableObject
{
    public float playerSpeed = 6f;
    public float enemySpeed = 3f;

    public int playerHealthStart = 3;
    public int enemyHealthStart = 1;
    public int enemyDamage = 1;

    public void DefaultValues()
    {
        playerSpeed = 6f;
        enemySpeed = 3f;

        playerHealthStart = 3;
        enemyHealthStart = 1;
        enemyDamage = 1;
    }
}
