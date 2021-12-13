using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class SetValue : MonoBehaviour
{
    public GameObject row;
    public Transform parent;
    public GameObject canvas;
    public GameObject leaderB;

    public void GetLeaderBoard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest()
        {
            StatisticName = "Neo Champion",
            StartPosition = 0,
            MaxResultsCount = 50
        },
        result =>
        {
            foreach(Transform item in parent)
            {
                Destroy(item.gameObject);
            }
            foreach (var item in result.Leaderboard)
            {
                GameObject newgo = Instantiate(row, parent);
                Text[] texts = newgo.GetComponentsInChildren<Text>();
                texts[0].text = (item.Position + 1).ToString();
                texts[1].text = item.DisplayName.ToString();
                texts[2].text = item.StatValue.ToString();
            }
        },
        error => { Debug.Log("Cant Get leaderboard"); }
        );
    }
    public void ChangeCanvas()
    {
        canvas.SetActive(false);
        leaderB.SetActive(true);
        GetLeaderBoard();
    }
    public void returnC()
    {
        canvas.SetActive(true);
        leaderB.SetActive(false);
    }
}
