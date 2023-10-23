using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    int playerSkin;
    public Image playerTop;
    public Sprite[] playerTopSprite;
    int currentTop;
    public Image playerMid;
    public Sprite[] playerMidSprite;
    int currentMid;
    public Image playerBot;
    public Sprite[] playerBotSprite;
    int currentBot;
    public StatBar[] stats;

    private void Start() {
        ChangeTop();
        ChangeMid();
        ChangeBot();
    }

    public void ChangeTop() {
        if (currentTop < playerTopSprite.Length - 1) {
            currentTop++;
        } else {
            currentTop = 0;
        }
        playerSkin = currentTop;
        PlayerPrefs.SetInt("Skin", playerSkin);
        playerTop.sprite = playerTopSprite[currentTop];
    }

    public void ChangeMid() {
        if (currentMid < playerMidSprite.Length - 1) {
            currentMid++;
        } else {
            currentMid = 0;
        }
        playerMid.sprite = playerMidSprite[currentMid];
    }

    public void ChangeBot() {
        if (currentBot < playerBotSprite.Length - 1) {
            currentBot++;
        } else {
            currentBot = 0;
        }
        playerBot.sprite = playerBotSprite[currentBot];
    }
}
