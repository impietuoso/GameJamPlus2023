using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelection : MonoBehaviour
{
    public TextMeshProUGUI[] stageText;

    public void ShowRecords() {
        GetRecord(0);
        GetRecord(1);
        GetRecord(2);
    }

    void GetRecord(int i) {
        int n = i + 1;
        string stageId = "Stage" + n;
        int recordTime = PlayerPrefs.GetInt(stageId, 150);
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
        stageText[i].text = minutes + "m " + seconds + "s";
        Debug.Log(seconds);
    }

    public void GoToStage(int stage) {
        SceneManager.LoadSceneAsync(stage);     
    }
}
