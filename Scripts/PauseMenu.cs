using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private static bool isPaused = false;

    private void Start() {
        pauseUI.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    private void Pause() {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
