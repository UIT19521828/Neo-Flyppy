using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
public class GameManager : MonoBehaviour
{
    public GameObject gameoverCanvar;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Gameover()
    {
        gameoverCanvar.SetActive(true);
        Time.timeScale = 0;
        int score =  ScoreCount.s;
        PlayerData.pd.AddMoney(score);      
        PlayerData.pd.NewHighScore(score);
    }
}
