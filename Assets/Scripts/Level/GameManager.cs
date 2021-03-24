using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
     * Reference to the gameplay parameters ScriptableObject.
     * Holds information used to set the Player and Enemy's 
     * speed, health and damage values.
     * */

    public GameplayParameters gameplayParameters;

    public GameObject levelCompletePanel;
    public GameObject gameOverPanel;

    private List<Coin> coins = new List<Coin>();
    [HideInInspector] public int coinsToCollect;
    [HideInInspector] public int coinsCollected;
    [HideInInspector] public int score;

    /*
     * Counts all <Coin> type GameObjects in the scene. 
     * Whichever number it counts is the number of coins
     * the player has to pick up to unlock the door.
     * */
    private void Awake()
    {
        foreach(Coin coin in FindObjectsOfType<Coin>())
        {
            coins.Add(coin);
        }
        coinsToCollect = coins.Count;
    }

    public void OnLevelComplete()
    {
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
