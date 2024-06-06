using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTime(float time)
    {
        int minutess = (int)(time / 60f);
        int second = (int)(time % 60f);

        text.text = minutess.ToString() + ":" + second.ToString("00");
    }
}
