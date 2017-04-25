using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    public Text FoodText;
    public Text WaterText;
    public Text PowerText;
    public Text TotalText;

    void Start()
    {
        FoodText.text = Resources.s_Instance.Air.ToString();
        WaterText.text = Resources.s_Instance.Water.ToString();
        PowerText.text = Resources.s_Instance.Power.ToString();
    }

	public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
