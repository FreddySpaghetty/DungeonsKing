using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GOMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI creditsText;
    int score = ScoreScript.instance.score;
    int credits = ScoreScript.instance.money;

    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        creditsText.text = credits.ToString() + " CREDITS";
        GameObject.Find("Player").SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("ScenaMappa");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
