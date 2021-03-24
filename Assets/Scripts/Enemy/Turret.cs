using System.Collections;
using UnityEngine;
using Player;

/*
 * _turretPivot and _projectileSpawnPos should be checked. 
 * Custom models should be checked so this arrangement makes sense.
 * 
 * Hinge 
 */

public class Turret : Enemy
{
    [Header("Projectile Prefab and Cooldown")]
    public float projectileCooldown;
    public GameObject projectilePrefab;

    [Header("Range")]
    public float rangeDetectionDistance;
    private Transform target;
    private Transform targetInRange;
    private bool alreadyTargeted;

    [Header("Turret")]
    public Transform _turretPivot;
    public Transform _projectileSpawnPos;

    Coroutine shoot;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Initialize();
    }

    private void FixedUpdate()
    {
        TargetDistance();
        PointToTarget();
    }

    void TargetDistance()
    {
        Vector3 distance = target.position - transform.position;

        if (distance.magnitude <= rangeDetectionDistance)
        {
            targetInRange = target;
            if (!alreadyTargeted)
            {
                alreadyTargeted = true;
                shoot = StartCoroutine(ShootProjectile());
            }
        }
        else
        {
            if (targetInRange != null)
            {
                //Debug.Log("Nullify!");
                targetInRange = null;
                alreadyTargeted = false;

                if (shoot != null)
                    StopCoroutine(shoot);
            }
        }
    }

    void PointToTarget()
    {
        if (targetInRange != null)
        {
            Vector3 Direction = targetInRange.position - _turretPivot.position;
            _turretPivot.transform.up = -Direction;
        }
    }

    IEnumerator ShootProjectile()
    {
        while (targetInRange != null)
        {
            yield return new WaitForSeconds(projectileCooldown);

            GameObject go = Instantiate(projectilePrefab, _projectileSpawnPos.position, _projectileSpawnPos.rotation);
            //Debug.Log(go.name);

            if (go.GetComponent<Projectile>())
                go.GetComponent<Projectile>().speed = speed;
        }
    }

    /*
     * If the GameplayParameter's enemyDamage is greater than 1
     * then collision with the turret would do too much damage.
     * This override is to ensure 1 damage on collision. 
     * Projectiles will still do 'enemyDamage' damage to the player
     * as they are their own entity and also derive from Enemy.
     */

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<PlayerAction>().DamagePlayer(1);
    }
}
