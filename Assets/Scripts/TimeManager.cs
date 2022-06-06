using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] ClockAnimation animation;
    [SerializeField] AlarmLogic alarm;
    public DateTime now;
    void Start()
    {
        now = UpdateTime.GetDateTime();
        StartCoroutine(TimeTick());
        StartCoroutine(SyncTime());
    }

    IEnumerator SyncTime() // ѕолучаем врем€
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(3600f);
            now = UpdateTime.GetDateTime();
        }
    }
    IEnumerator TimeTick()
    {
        while (true)
        {
            now = now.AddSeconds(1); // ƒобавл€ем 1 сек
            if(now.Second == alarm.AlarmTime.Second && // проверка не пора ли включить звук будильника 
               now.Minute == alarm.AlarmTime.Minute &&
               now.Hour   == alarm.AlarmTime.Hour)
            {
                
                this.GetComponent<AudioSource>().Play(); // запуск мелодии будильника
            }

            animation.min = now.Minute;
            animation.sec = now.Second;
            animation.hour = now.Hour;// обновл€ем значени€ 
            animation.UpdateValue();
            yield return new WaitForSecondsRealtime(1f); //ожидаем одну сек 
        }
    }
}
