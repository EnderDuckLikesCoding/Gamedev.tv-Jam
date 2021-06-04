using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private GameObject inkMissile;
    [SerializeField] private float projectileSpeed;
    private float distance = 5f;
    private float destroyDelay = 5f;
    private float shotCounter;
    private bool canFire;
    private Transform target;
    private int waypointIndex = 0;

    private void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
 
    private void Update() {
        if (waypointIndex <= wayPoints.Length) {
            Vector2 targetPosition = wayPoints[waypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            RotateTowardsTarget(targetPosition);

            if (new Vector2(transform.position.x, transform.position.y) == targetPosition) {
                waypointIndex++;
                if (waypointIndex >= wayPoints.Length) {
                    waypointIndex = 0;
                }
            }
        }

        if (Vector2.Distance(transform.position, target.position) <= distance) {
            CountDownAndShoot();
        }
    }

    private void RotateTowardsTarget(Vector3 target) {
        Vector3 vectorToTarget = target - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, rotationSpeed * Time.deltaTime);
    }

    private void Fire() {
        Vector2 direction = target.position - transform.position;
        GameObject projectile = Instantiate(
            inkMissile,
            transform.position,
            Quaternion.identity
        ) as GameObject;

        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * projectileSpeed, direction.y * projectileSpeed);
        
        Destroy(projectile, destroyDelay);
    }

    private void CountDownAndShoot() {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0) {
            Fire();
            shotCounter = 0.5f;
        }
    }
}
