using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] goldSpawnPoints;
    [SerializeField] private GameObject goldPrefab;
    [SerializeField] private GameObject[] anglerfishSpawnPoints;
    [SerializeField] private GameObject anglerfishPrefab;
    [SerializeField] private float maxGold = 5;
    [SerializeField] private float maxAnglerfish = 5;
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D mainLight;
    [SerializeField] private float initialBlindTime;
    [SerializeField] private TMP_Text scoreText;
    private int goldCount = 0;
    private float startTime;
    private float blindTime;
    private float normalIntensity = 1f;

    private void Start() {
        for (int i = 0; i <= maxGold; i++) {
            Instantiate(
                goldPrefab, 
                goldSpawnPoints[Random.Range(0, goldSpawnPoints.Length)].transform.position, 
                Quaternion.identity);
        }

        for (int i = 0; i <= maxAnglerfish; i++) {
            Instantiate(
                anglerfishPrefab, 
                anglerfishSpawnPoints[Random.Range(0, anglerfishSpawnPoints.Length)].transform.position, 
                Quaternion.identity);
        }
        startTime = Time.time;
        blindTime = initialBlindTime;
    }

    private void Update() {
        blindTime -= Time.deltaTime;

        if (blindTime <= 0) {
            blindTime = initialBlindTime;
            UnblindPlayer();
        }
    }

    public void BlindPlayer() {
        blindTime = initialBlindTime;
        mainLight.intensity = 0.1f;
    }

    private void UnblindPlayer() {
        mainLight.intensity = normalIntensity;
    }

    public void SetLightIntensity(float intensity) {
        mainLight.intensity = Mathf.Lerp(normalIntensity, intensity, Mathf.SmoothStep(0.0f, 1.0f, 0.1f));
        normalIntensity = intensity;
    }

    public IEnumerator KillPlayer() {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Time.timeScale = 0;
        yield return new WaitForSeconds(2);
        Time.timeScale = 1;
        SceneManager.LoadScene("Game Over Scene");
    }

    public void IncreaseGoldCount() {
        goldCount++;
        scoreText.text = $"Gold Collected: {goldCount.ToString()}";

        if (goldCount > maxGold) {
            scoreText.text = "Done! Return to Trainer";
        }
    }

    public void WinGame() {
        if (goldCount >= maxGold + 1) {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
