using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anglerfish : MonoBehaviour
{
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D mainLight;
    [SerializeField] private SpriteRenderer spriteRenderer1;
    [SerializeField] private SpriteRenderer spriteRenderer2;
    [SerializeField] private SpriteRenderer spriteRenderer3;
    [SerializeField] private SpriteRenderer spriteRenderer4;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed = 5f;
    private bool isHunting = false;
    private Transform target;

    private void Start() {
        spriteRenderer1.enabled = false;
        spriteRenderer2.enabled = false;
        spriteRenderer3.enabled = false;
        spriteRenderer4.enabled = false;
        mainLight.enabled = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {
        if (isHunting == true) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            RotateTowardsTarget(target.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            isHunting = true;
            mainLight.enabled = true;
            spriteRenderer1.enabled = true;
            spriteRenderer2.enabled = true;
            spriteRenderer3.enabled = true;
            spriteRenderer4.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene("Game Over Scene");
        }
    }

    private void RotateTowardsTarget(Vector3 target) {
        Vector3 vectorToTarget = target - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, rotationSpeed * Time.deltaTime);
    }
}
