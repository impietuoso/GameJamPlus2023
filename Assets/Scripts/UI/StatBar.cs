using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    public GameObject[] bars;
    public void ActiveBars(int ammount) {
        if (bars.Length-1 >= ammount)
            for (int i = 0; i < ammount; i++) {
                bars[i].SetActive(true);
            }
    }
}
