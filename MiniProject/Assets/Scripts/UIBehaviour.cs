using UnityEngine;
using TMPro;
using System;

public class UIBehaviour : MonoBehaviour
{
    public TMP_Text clockText;
    private int startTime = 10;
    private int endTime = 22;
    public float timeOfDay = 5f;

    public bool dayEnded = false;

    private float minutesCounter;
    private int hour;
    private int minute;
    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = (timeOfDay * 60f) / ((endTime - startTime) * 60f);
        hour = startTime;
        minute = 0;

        UpdateClockText();

    }

    private void UpdateClockText()
    {
        clockText.text = $"{hour:00}:{minute:00}";
    }

    // Update is called once per frame
    void Update()
    {
        if (hour >= endTime)
        {
            dayEnded = true;
            return;
        }

        minutesCounter += Time.deltaTime;
        if (minutesCounter >= speed)
        {
            minutesCounter -= speed;
            minute++;
            if (minute >= 60)
            {
                minute = 0;
                hour++;
            }
            UpdateClockText();

            if (hour >= endTime)
            {
                dayEnded = true;
                hour = endTime;
                UpdateClockText();
            }
        }

    }
}
