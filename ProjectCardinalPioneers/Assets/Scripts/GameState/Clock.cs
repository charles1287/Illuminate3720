using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {
    const float _secondsPerDay = 88800f;

    int _day;
    //The current time of the day represented as seconds
    float _time;

    public float Timescale;
    public CameraScript cam;
    public Color DawnColor;
    public Color DayColor;
    public Color NightColor;

    Color getTintColor()
    {
        float quarter = _secondsPerDay / 4;
        if(0.0 <= _time && _time < quarter)
        {
            float factor = (_time) / quarter;
            return Color.Lerp(NightColor, DawnColor, factor);
        }
        else if (quarter <= _time && _time < 2 * quarter)
        {
            float factor = (_time - quarter) / quarter;
            return Color.Lerp(DawnColor, DayColor, factor);
        }
        else if (2 * quarter <= _time && _time < 3 * quarter)
        {
            float factor = (_time - 2 * quarter) / quarter;
            return Color.Lerp(DayColor, DawnColor, factor);
        }
        else
        {
            float factor = (_time - 3 * quarter) / quarter;
            return Color.Lerp(DawnColor, NightColor, factor);
        }
    }

    void Start()
    {
        _day = 1;
        _time = 0f;

        StartCoroutine("UpdateTint");
    }

    void Update()
    {
        _time += Timescale * Time.deltaTime;
        if(_time > _secondsPerDay)
        {
            _time = 0f;
            _day++;
        }
    }

    IEnumerator UpdateTint()
    {
        float updateTime = 10f;
        while(true)
        {
            updateTime += Time.deltaTime;
            if(updateTime > 0.03f)
            {
                updateTime = 0;
                cam.SetTint(getTintColor());
            }

            yield return null;
        }
    }
}
