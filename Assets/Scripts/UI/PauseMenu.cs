using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseWindow;
    bool paused;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    void Pause() {
        paused = !paused;
        pauseWindow.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }

    public void ForceUnpause() {
        paused = false;
        pauseWindow.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToMenu() {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
