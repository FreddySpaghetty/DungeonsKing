using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public MapManager mapManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI killText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI levelText;
    public int scoreToAdd;

    public int score;
    public int highscore = 0;
    public int money = 0;
    int level;
    int kill;
    
    void Awake(){
        instance = this;
        score = 0;
    }
    
    void Start()
    {   

        if (AfterDeathManager.Load()!=null)
        {
            highscore = AfterDeathManager.Load().score;    
        }
        scoreText.text = score.ToString() + " POINTS";
        highScoreText.text = "HIGHSCORE " + highscore.ToString();

        moneyText.text = money.ToString() + " MONEY";

        levelText.text = "LEVEL " + level;
    }

    void Update()
    {
        kill = MapManager.instance.countFinaleKill();
        if(kill > 0){
            killText.text = kill.ToString() + " ENEMIES ";
        }else{
            killText.text = "GO EXIT";
        }

        levelText.text = "LEVEL " + MapManager.instance.level;
    }
    public void addPoint(){
        score += 11;
        scoreText.text = score.ToString() + " POINTS";
    }
    public void countKill(){
        killText.text = kill.ToString() + " KILL";
    }
    public void addMoney(){
        money += 1;
        moneyText.text = money.ToString() + " MONEY";
    }

    public void addPointFood(){
        score += 11;
        scoreText.text = score.ToString() + " POINTS";
    }
    public void addPointSoda(){
        score += 11;
        scoreText.text = score.ToString() + " POINTS";
    }
}

