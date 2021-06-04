using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    [SerializeField] private GameObject particles;

    private void Start() {
        particles.GetComponent<ParticleSystem>().Play();    
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
