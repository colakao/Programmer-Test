using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Opens the GameOver Panel/Screen.
 */
public class PlayerFell : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        FindObjectOfType<GameManager>().OnGameOver();
    }
}
