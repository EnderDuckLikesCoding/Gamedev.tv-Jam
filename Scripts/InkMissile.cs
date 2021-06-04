using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkMissile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GameObject menu = GameObject.FindGameObjectWithTag("GameUI");
            menu.GetComponent<GameManager>().BlindPlayer();
            Destroy(this.gameObject);
        }
    }
}
