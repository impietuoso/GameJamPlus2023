using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public static PlayerSounds instance;
    public AudioClip jump;
    public AudioClip hit;
    public AudioClip speed;
    public AudioClip win;

    private void Awake() {
        instance = this;
    }
}
