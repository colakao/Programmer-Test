using System.Collections;
using UnityEngine;

/*
 * The GameObject that holds this script gets destroyed after
 * collecting all <Coin> type items on the scene.
 */

public class Gate : MonoBehaviour
{
    GameManager _gm;

    private void Awake()
    {
        _gm = FindObjectOfType<GameManager>();
        StartCoroutine(CustomUpdate());
    }

    IEnumerator CustomUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (_gm != null && _gm.coinsCollected >= _gm.coinsToCollect)
                Destroy(gameObject);
        }
    }
}
