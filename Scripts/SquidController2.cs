using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidController2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Transform[] wayPoints;
    private int waypointIndex = 0;
 
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
    }

    private void RotateTowardsTarget(Vector3 target) {
        Vector3 vectorToTarget = target - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, rotateSpeed * Time.deltaTime);
    }
}