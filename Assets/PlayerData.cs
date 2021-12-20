using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData pd;
    public List<bool> unlock = new List<bool>();
    private int selectedSkin;
    private int money;
    private int highScore;
    private float v = (float)0.7;
    private float mt = (float)1.8;

    public int SelectedSkin { get => selectedSkin; set => selectedSkin = value; }
    public int Money { get => money; set => money = value; }
    public int HighScore { get => highScore; set => highScore = value; }
    public float V { get => v; set => v = value; }
    public float Mt { get => mt; set => mt = value; }

    private void Awake()
    {
        pd = this;
        DontDestroyOnLoad(this);
    }
    public void GetShopUnlock(string skinin)
    {
        for (int i = 0; i < skinin.Length; i++) 
        {
            if (int.Parse(skinin[i].ToString()) > 0) { unlock.Add(true); }
            else { unlock.Add(false); }
        }
    }
    public string ReturnUnlock()
    {
        string kq = "";
        for (int i = 0; i < unlock.Count; i++)
        {
            if (unlock[i] == true) kq += "1";
            else kq += "0";
        }
        return kq;
    }
    public void GetSelect(string s)
    {
        selectedSkin = int.Parse(s);
    }
    
    public void GetMoney(string m)
    {
        money = int.Parse(m);
    }
    public void GetHighScore(string h)
    {
        highScore = int.Parse(h);
    }
    public void BuySkin(int x, int s)
    {
        if (money >= x)
        {
            money -= x;
            unlock[s] = true;
            UserAccount.Instance.SetUnlockM(ReturnUnlock(), money.ToString());
        }
        else Debug.Log("Not enoungh money");
    }
    public void AddMoney(int x)
    {
        money += x;
        UserAccount.Instance.SetMoney(money.ToString());
    }
    public void NewHighScore(int x)
    {
        if (x > highScore)
        {
            highScore = x;
            UserAccount.Instance.SetHighScore(x.ToString());
        }
    }
    public void SetSelect(int x)
    {
        selectedSkin = x;
        UserAccount.Instance.SetSelected(selectedSkin.ToString());
    }
}
