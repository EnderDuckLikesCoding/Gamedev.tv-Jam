using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GameObject.FindGameObjectWithTag("GameUI").GetComponent<GameManager>().WinGame();
        }
    }
}
