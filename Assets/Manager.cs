using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text text;
    private int minute;
    private float second;

    // Update is called once per frame
    void Update()
    {
        minute = (int) (Time.timeSinceLevelLoad / 60);
        second = Time.timeSinceLevelLoad - (minute * 60);
        if (second >= 10)
        {
            text.text = minute + ":" + second;
        }
        else
        {
            text.text = minute + ":0" + second;
        }
    }
}
