using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmLogic : MonoBehaviour
{
    [SerializeField] GameObject hourGameObject;
    [SerializeField] GameObject minGameObject;
    [SerializeField] GameObject secGameObject;

    [SerializeField] Text hoursText;
    [SerializeField] Text minText;
    [SerializeField] Text secText;

    public DateTime AlarmTime;
    [SerializeField] GameObject ClockCanvas;
    [SerializeField] GameObject AlarmCanvas;

    public void Show() // ѕоказать меню будильника
    {
        ClockCanvas.SetActive(false);
        AlarmCanvas.SetActive(true);
    }
    public void UpdateClockValues()// ќтображение времени будильника
    {
        minGameObject.transform.rotation = Quaternion.Euler(0, 0, 360 / 60 * -Convert.ToInt32(minText.text));
        secGameObject.transform.rotation = Quaternion.Euler(0, 0, 360 / 60 * -Convert.ToInt32(secText.text));
        hourGameObject.transform.rotation = Quaternion.Euler(0, 0, 360 / 12 * -Convert.ToInt32(hoursText.text));
    }
    public void Submit()// установить будильник
    {
        AlarmTime = new DateTime();
        AlarmTime = AlarmTime.Date + 
            new TimeSpan(
            Convert.ToInt32(hoursText.text),
            Convert.ToInt32(minText.text),
            Convert.ToInt32(secText.text));
        ClockCanvas.SetActive(true);
        AlarmCanvas.SetActive(false);
    }
}
