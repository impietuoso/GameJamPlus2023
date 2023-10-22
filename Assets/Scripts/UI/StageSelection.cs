using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelection : MonoBehaviour
{
    public TextMeshProUGUI[] stageText;

    public void ShowRecords() {
        for (int i = 0; i < stageText.Length; i++) {
            GetRecord(i);
        }
    }

    void GetRecord(int i) {
        string stageId = "Stage" + i + 1;
        int recordTime = PlayerPrefs.GetInt(stageId, 10);

        int minutes = 0;
        int removedSeconds = 0;
        while (recordTime > 59) {
            minutes++;
            removedSeconds += 60;
        }
        int seconds = recordTime - removedSeconds;
        stageText[i].text = minutes + "m " + seconds + "s";
    }

    public void GoToStage(int stage) {
        SceneManager.LoadSceneAsync(stage);     
    }
}
