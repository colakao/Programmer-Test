using UnityEngine;
using TMPro;
using Player;

/*
 * Updates de HUD and also the "Score" text in the LevelComplete Panel.
 */
public class HUD : MonoBehaviour
{
    GameManager _gm;
    PlayerAction _player;
 
    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI scoreDisplayHUD;
    public TextMeshProUGUI scoreDisplayLevelCompletePanel;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerAction>();
        _gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        healthDisplay.text = "Health: " + _player.health;
        scoreDisplayHUD.text = "Collected: " + _gm.coinsCollected + "/" + _gm.coinsToCollect;
        scoreDisplayLevelCompletePanel.text = "Score: " + _gm.score;
    }
}
