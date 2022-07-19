using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{   
    public GameObject score = GameObject.FindGameObjectWithTag("CanvasScore");
    public GameObject player= GameObject.FindGameObjectWithTag("Player");
    // Start is called before the first frame update
    public void Next()
    {
        if(ScoreScript.instance.score >=AfterDeathManager.Load().score)

        {
            score.GetComponent<ScoreScript>().score=ScoreScript.instance.score;
            AfterDeathManager.Save(player.GetComponent<PlayerManager>(),player.GetComponent<PlayerCombact>(),score.GetComponent<ScoreScript>());
        }

        else
        {
            score.GetComponent<ScoreScript>().score=AfterDeathManager.Load().score;
            AfterDeathManager.Save(player.GetComponent<PlayerManager>(),player.GetComponent<PlayerCombact>(),score.GetComponent<ScoreScript>());
        }

        GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().Resume();
        SceneManager.LoadScene("GameOver");
    }
}
