using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public float currentTime;
    public TextMeshProUGUI currentTimerText;
    public int recordTime;
    public TextMeshProUGUI recordText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public GameObject winButton;
    public GameObject retryButton;
    public PlayerInput pi;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        currentTime += Time.deltaTime;
        if (!gameOver)
            currentTimerText.text = currentTime.ToString("F0") + "s";

        //if (Input.GetKeyDown(KeyCode.K)) Win();
    }

    public void Win() {
        string stageId = "Stage" + SceneManager.GetActiveScene().buildIndex.ToString();
        recordTime = (int)currentTime;
        gameOver = true;
        if (recordTime < PlayerPrefs.GetInt(stageId, 150))
            PlayerPrefs.SetInt(stageId, recordTime);

        int minutes = 0;

        if (recordTime > 59) {
            minutes++;
            recordTime -= 60;
        }
        if (recordTime > 59) {
            minutes++;
            recordTime -= 60;
        }
        if (recordTime > 59) {
            minutes++;
            recordTime -= 60;
        }

        int seconds = recordTime;
        recordText.text = minutes + "m " + seconds + "s";

        gameOverPanel.SetActive(true);
        gameOverText.text = "Fase\nConclu�da";
        if (SceneManager.GetActiveScene().buildIndex != 3)
            winButton.SetActive(true);
        retryButton.SetActive(false);
        Time.timeScale = 0;
    }

    void GameOver() {
        string stageId = "Stage" + SceneManager.GetActiveScene().buildIndex.ToString();
        recordTime = PlayerPrefs.GetInt(stageId, 150);
        gameOver = true;
        pi.enabled = false;
        int minutes = 0;

        if (recordTime > 59) {
            minutes++;
            recordTime -= 60;
        }
        if (recordTime > 59) {
            minutes++;
            recordTime -= 60;
        }
        if (recordTime > 59) {
            minutes++;
            recordTime -= 60;
        }

        int seconds = recordTime;
        recordText.text = minutes + "m " + seconds + "s";
        gameOverPanel.SetActive(true);
        gameOverText.text = "Voc�\nPerdeu";
        winButton.SetActive(false);
        retryButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextState() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void ReloadScene() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu() {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            GameOver();
        }
    }
}