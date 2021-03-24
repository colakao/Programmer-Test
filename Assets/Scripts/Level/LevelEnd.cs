using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Opens the LevelComplete Panel/Screen.
 */
public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().OnLevelComplete();
        }
    }
}
