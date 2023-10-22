using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBlock : MonoBehaviour
{
    public void Win() {
        Invoke("CallWin", 1f);
    }

    void CallWin() {
        GameManager.instance.Win();
    }
}
