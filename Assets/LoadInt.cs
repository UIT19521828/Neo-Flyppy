using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInt : MonoBehaviour
{
    public Text tien;
    public Text hiS;

    private void Update()
    {
        tien.text = PlayerData.pd.Money.ToString();
        hiS.text = PlayerData.pd.HighScore.ToString();
    }
}
