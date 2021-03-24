using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector3 eulerRotation;
    public int scorePoints = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(eulerRotation * Time.deltaTime);
    }

    /*
     * This tells the GameManager whenever it collects a coin.
     * GameManager can keep track of collected items this way.
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().coinsCollected++;
            FindObjectOfType<GameManager>().score += scorePoints;
            Destroy(gameObject);
        }
    }
}
