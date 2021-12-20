using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public void Eazy()
    {
        PlayerData.pd.V = (float)0.5;
        PlayerData.pd.Mt = (float)2.5;
    }
    public void Med()
    {
        PlayerData.pd.V = (float)0.7;
        PlayerData.pd.Mt = (float)1.8;
    }
    public void Hard()
    {
        PlayerData.pd.V = 1;
        PlayerData.pd.Mt = (float)1.6;
    }
}
