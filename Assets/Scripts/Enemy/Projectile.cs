using UnityEngine;
using Player;

public class Projectile : Enemy
{
    public GameObject explosionPrefab;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3);
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.forward * speed;
    }

    /*
     * Override to destroy the projectile with any collision.
     */
    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerAction>())
            other.gameObject.GetComponent<PlayerAction>().DamagePlayer(damage);

        OnCollision();
    }

    /*
     * This isn't implemented but it's to add an explosion on collision.
     * Whatever gets instantiated will be destroyed some amount of time after.
     */

    void OnCollision()
    {
        if (explosionPrefab != null)
        {
            GameObject go = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(go, 3);
        }

        Destroy(gameObject);
    }
}
