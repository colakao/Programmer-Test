using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public float speed = 1f;
    [HideInInspector] public int health = 1;
    [HideInInspector] public int damage = 1;

    public void Initialize()
    {
        var stats = FindObjectOfType<GameManager>().gameplayParameters;

        speed = stats.enemySpeed;
        health = stats.enemyHealthStart;
        damage = stats.enemyDamage;
    }

    /*
     * Any collision with an Enemy or derived will reduce the 
     * player's health by 'damage'. Value can be adjusted with
     * the GameplayParameters ScriptableObject.
     */

    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerAction>())
            other.gameObject.GetComponent<PlayerAction>().DamagePlayer(damage);
    }
}
