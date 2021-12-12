using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkin : MonoBehaviour
{
    private int choose;
    public List<Sprite> sprites;
    public List<AnimatorOverrideController> animators;
    public List<int> price;
    public SpriteRenderer sr;
    public Animator bird;
    public Text giatien;
    public Button btnBuy;
    public Button btnSelect;
    private void Start()
    {
        choose = PlayerData.pd.SelectedSkin;
        LoadAni();
    }
    public void LoadAni()
    {
        sr.sprite = sprites[choose];
        bird.runtimeAnimatorController = animators[choose];
        giatien.text = price[choose].ToString();
        if (PlayerData.pd.unlock[choose] == true)
        {
            btnBuy.gameObject.SetActive(false);
            btnSelect.gameObject.SetActive(true);
        }
        else if (PlayerData.pd.unlock[choose] == false)
        {
            btnBuy.gameObject.SetActive(true);
            btnSelect.gameObject.SetActive(false);
        }
    }
    public void Phai()
    {
        choose++;
        if (choose == sprites.Count)
        {
            choose = 0;
        }
        LoadAni();
    }
    public void Trai()
    {
        choose--;
        if(choose < 0)
        {
            choose = sprites.Count - 1;
        }
        LoadAni();
    }
    public void BuySkin()
    {
        PlayerData.pd.BuySkin(price[choose], choose);
        btnBuy.gameObject.SetActive(false);
        btnSelect.gameObject.SetActive(true);
    }
    public void ChooseThis()
    {
        PlayerData.pd.SetSelect(choose);
    }
}
