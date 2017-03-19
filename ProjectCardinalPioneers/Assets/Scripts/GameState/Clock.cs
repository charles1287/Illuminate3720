using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {
    const float _secondsPerDay = 88800f;
    const float _timeScale = 500f;

    int _day;
    //The current time of the day represented as seconds
    public float _timeSeconds;
    
    public CameraScript cam;
    public Color DawnColor;
    public Color DayColor;
    public Color NightColor;

    Color getTintColor()
    {
        float quarter = _secondsPerDay / 4;
        if(0.0 <= _timeSeconds && _timeSeconds < quarter)
        {
            float factor = (_timeSeconds) / quarter;
            return Color.Lerp(NightColor, DawnColor, factor);
        }
        else if (quarter <= _timeSeconds && _timeSeconds < 2 * quarter)
        {
            float factor = (_timeSeconds - quarter) / quarter;
            return Color.Lerp(DawnColor, DayColor, factor);
        }
        else if (2 * quarter <= _timeSeconds && _timeSeconds < 3 * quarter)
        {
            float factor = (_timeSeconds - 2 * quarter) / quarter;
            return Color.Lerp(DayColor, DawnColor, factor);
        }
        else
        {
            float factor = (_timeSeconds - 3 * quarter) / quarter;
            return Color.Lerp(DawnColor, NightColor, factor);
        }
    }

    void Start()
    {
        _day = 1;
        _timeSeconds = 0f;

        StartCoroutine("UpdateTint");
    }

    void Update()
    {
        _timeSeconds += _timeScale * Time.deltaTime;
        if(_timeSeconds > _secondsPerDay)
        {
            _timeSeconds = 0f;
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
