using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

    static public int score = 1000;

    void Awake()
    {
        if (PlayerPrefs.HasKey("AplePickerHighscore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        PlayerPrefs.SetInt("ApplePickerHighScore", score);
    }

	void Update () {

        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;

        if(score > PlayerPrefs.GetInt("ApplePickerHighScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }

	}
}
