using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGround : MonoBehaviour
{
    public static BGround instance;
    public SpriteRenderer sr;
    public List<Sprite> bg;
    private int current = 0;
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    public void ChangeBG(int which)
    {
        current = which;
        sr.sprite = bg[current];
    }
    public void Destroythis()
    {
        Destroy(this.gameObject);
    }
}
