using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangerHorizontal : MonoBehaviour
{
    [SerializeField] private float upLightIntensity;
    [SerializeField] private float downLightIntensity;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (other.gameObject.GetComponent<PlayerMovement>().direction.y < 0f) {
                GameObject.FindGameObjectWithTag("GameUI").GetComponent<GameManager>().SetLightIntensity(downLightIntensity);
            }
            else if (other.gameObject.GetComponent<PlayerMovement>().direction.y > 0f) {
                GameObject.FindGameObjectWithTag("GameUI").GetComponent<GameManager>().SetLightIntensity(upLightIntensity);
            }
        }
    }
}
