using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Quit() {
        Application.Quit();
    }

    public void LoadGame() {
        SceneManager.LoadScene("Scene1");
    }
}
