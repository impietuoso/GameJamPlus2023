using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public float timeLimit;
    public float currentTime;
    public int recordTime;
    public TextMeshProUGUI recordText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public PlayerInput pi;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        currentTime += Time.deltaTime;

        if (currentTime >= timeLimit) {
            if (!gameOver)
                GameOver();
        }
    }

    public void Win() {
        recordTime = (int)currentTime;
        string stageId = "Stage" + SceneManager.GetActiveScene().buildIndex.ToString();

        if (recordTime > PlayerPrefs.GetInt(stageId, 0))
            PlayerPrefs.SetInt(stageId, recordTime);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void GameOver() {
        string stageId = "Stage" + SceneManager.GetActiveScene().buildIndex.ToString();
        recordTime = PlayerPrefs.GetInt(stageId, 0);
        gameOver = true;
        pi.enabled = false;
        int minutes = 0;
        int removedSeconds = 0;
        while (recordTime > 59) {
            minutes++;
            removedSeconds += 60;
        }
        int seconds = recordTime - removedSeconds;
        recordText.text = "Record Time: " + minutes + "m : " + seconds + "s";
        gameOverPanel.SetActive(true);
    }

    public void ReloadScene() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            ReloadScene();
        }
    }
}