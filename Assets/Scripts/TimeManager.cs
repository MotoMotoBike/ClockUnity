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

    IEnumerator SyncTime() // �������� �����
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
            now = now.AddSeconds(1); // ��������� 1 ���
            if(now.Second == alarm.AlarmTime.Second && // �������� �� ���� �� �������� ���� ���������� 
               now.Minute == alarm.AlarmTime.Minute &&
               now.Hour   == alarm.AlarmTime.Hour)
            {
                
                this.GetComponent<AudioSource>().Play(); // ������ ������� ����������
            }

            animation.min = now.Minute;
            animation.sec = now.Second;
            animation.hour = now.Hour;// ��������� �������� 
            animation.UpdateValue();
            yield return new WaitForSecondsRealtime(1f); //������� ���� ��� 
        }
    }
}
