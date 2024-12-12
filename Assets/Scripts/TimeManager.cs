using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    private void OnEnable()
    {
        Player.onLevelUp += StartSlowdown;
        UpgradeManager.onUpgradeChosen += ResumeTime;
    }

    private void OnDisable()
    {
        Player.onLevelUp -= StartSlowdown;
        UpgradeManager.onUpgradeChosen -= ResumeTime;
    }

    public void StartSlowdown()
    {
        StartCoroutine(SlowDownTime());
    }

    private IEnumerator SlowDownTime()
    {
        while (Time.timeScale > 0.015f)
        {
            Time.timeScale -= 0.0125f;
            yield return new WaitForSecondsRealtime(0.00175f);
        }
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
