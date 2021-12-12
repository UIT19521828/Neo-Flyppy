using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInt : MonoBehaviour
{
    public Text tien;
    public Text hiS;
    void Start()
    {

    }
    private void Update()
    {
        tien.text = PlayerData.pd.Money.ToString();
        hiS.text = PlayerData.pd.HighScore.ToString();
    }
}
