using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Base Player script.
 * Initialize() grabs the GameplayParameters ScriptableObject values
 * and uses them for 'health' and 'speed'.
 */

namespace Player
{
    public class Player : MonoBehaviour
    {
        [HideInInspector] public int health;
        [HideInInspector] public float speed;

        GameManager _gm;

        public void Initialize()
        {
            _gm = FindObjectOfType<GameManager>();

            health = _gm.gameplayParameters.playerHealthStart;
            speed = _gm.gameplayParameters.playerSpeed;
        }

        public void DamagePlayer(int damage)
        {
            if (damage >= health)
            {
                health = 0;
                _gm.OnGameOver();
            }
            else
            {
                health -= damage;
            }
        }
    }
}