using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockAnimation : MonoBehaviour
{
    public int hour = 0;
    [SerializeField] GameObject hourGameObject;
    public int min = 0;
    [SerializeField]GameObject minGameObject;
    public int sec = 0;
    [SerializeField] GameObject secGameObject;

    [SerializeField] Text hoursText;
    [SerializeField] Text minText;
    [SerializeField] Text secText;
    public void UpdateValue() // Обновление стрелок часов
    {
        minGameObject.transform.rotation = Quaternion.Euler(0, 0, 360 / 60 * -min);
        secGameObject.transform.rotation = Quaternion.Euler(0, 0, 360 / 60 * -sec);
        hourGameObject.transform.rotation = Quaternion.Euler(0, 0, 360 / 12 * -hour);
        hoursText.text = hour.ToString();
        minText.text = min.ToString();
        secText.text = sec.ToString();
    }
}
