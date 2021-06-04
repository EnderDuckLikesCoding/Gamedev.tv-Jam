using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float speed;
    [SerializeField] private GameObject particles;
    private SpriteRenderer spriteRenderer;
    public Vector2 direction;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float distance = speed * Time.deltaTime;

        if (Input.GetMouseButton(0)) {
            transform.position = Vector2.MoveTowards(transform.position, mousePos, distance);
            particles.GetComponent<ParticleSystem>().Play();
        }
        else {
            particles.GetComponent<ParticleSystem>().Stop();
        }
    }
}
