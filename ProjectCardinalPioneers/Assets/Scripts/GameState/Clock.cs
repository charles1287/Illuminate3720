using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {
    const float _secondsPerDay = 88800f;
    const float _realTimeSecondsPerDay = 210;
    const float _timeScale = _secondsPerDay / _realTimeSecondsPerDay;
    const float _betweenDelay = 3f;

    int _day;
    //The current time of the day represented as seconds
    public float _timeSeconds;
    
    public CameraScript cam;
    public PlayerController player;
    public Color DawnColor;
    public Color DayColor;
    public Color NightColor;

    Text _timerText;
    Text _foodText;
    Text _waterText;
    Text _powerText;
    Text _dayText;

    Color getTintColor()
    {
        float sixth = _secondsPerDay / 8;
        if(0.0 <= _timeSeconds && _timeSeconds < sixth)
        {
            float factor = (_timeSeconds) / sixth;
            return Color.Lerp(NightColor, DawnColor, factor);
        }
        else if (sixth <= _timeSeconds && _timeSeconds < 2 * sixth)
        {
            float factor = (_timeSeconds - sixth) / sixth;
            return Color.Lerp(DawnColor, DayColor, factor);
        }
        else if (2 * sixth <= _timeSeconds && _timeSeconds < 4 * sixth)
        {
            return DayColor;
        }
        else if(4 * sixth <= _timeSeconds && _timeSeconds < 5 * sixth)
        {
            float factor = (_timeSeconds - 4 * sixth) / sixth;
            return Color.Lerp(DayColor, DawnColor, factor);
        }
        else
        {
            float factor = (_timeSeconds - 5 * sixth) / sixth;
            return Color.Lerp(DawnColor, NightColor, factor);
        }
    }
    
    void Start()
    {
        _day = 1;
        _timeSeconds = 0f;

        StartCoroutine("UpdateTint");

        _timerText = GameObject.Find("TimeText").GetComponent<Text>();
        _foodText = GameObject.Find("FoodText").GetComponent<Text>();
        _waterText = GameObject.Find("WaterText").GetComponent<Text>();
        _powerText = GameObject.Find("PowerText").GetComponent<Text>();
        _dayText = GameObject.Find("DayText").GetComponent<Text>();
        StartCoroutine("UpdateUI");
        StartCoroutine("FadeDayText");
    }

    void Update()
    {
        _timeSeconds += _timeScale * Time.deltaTime;
        if(_timeSeconds > _secondsPerDay)
        {
            NextDay();
        }
    }
    
    void NextDay()
    {
        player.enabled = false;
        //UpdateResources();

        _timeSeconds = 0f;
        _day++;

        _dayText.text = "Day " + _day.ToString();
        StartCoroutine("FadeDayText");

        ComponentSpawner.s_Instance.SpawnPod();
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

    IEnumerator UpdateUI()
    {
        while (true)
        {
            int secondsLeft = (int) ((_secondsPerDay - _timeSeconds) * _realTimeSecondsPerDay / _secondsPerDay); 

            _timerText.text = secondsLeft.ToString();
            _foodText.text = Resources.instance.Food.ToString();
            _waterText.text = Resources.instance.Water.ToString();
            _powerText.text = Resources.instance.Power.ToString();
                        
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator FadeDayText()
    {
        while (_dayText.color.a < 1f)
        {
            _dayText.color = new Color(1f, 1f, 1f, _dayText.color.a + 0.005f);
            yield return null;
        }

        yield return new WaitForSeconds(3);

        player.enabled = true;

        while (_dayText.color.a > 0f)
        {
            _dayText.color = new Color(1f, 1f, 1f, _dayText.color.a - 0.005f);
            yield return null;
        }

    }
}
