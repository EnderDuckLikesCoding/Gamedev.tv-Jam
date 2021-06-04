using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private Sprite[] goldSprites;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = goldSprites[Random.Range(0, goldSprites.Length)];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GameObject.FindGameObjectWithTag("GameUI").GetComponent<GameManager>().IncreaseGoldCount();
            Destroy(this.gameObject);
        }
    }
}
