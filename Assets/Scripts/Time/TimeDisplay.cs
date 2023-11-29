using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    public TMP_Text timeText; 

    void Update()
    {

        int hour = System.DateTime.Now.Hour;
        int minute = System.DateTime.Now.Minute;


        timeText.text = hour.ToString("D2") + ":" + minute.ToString("D2");
    }
}