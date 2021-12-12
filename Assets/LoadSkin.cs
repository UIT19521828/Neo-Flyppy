using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSkin : MonoBehaviour
{
    private int choose;
    public List<Sprite> sprites;
    public List<AnimatorOverrideController> animators;
    public SpriteRenderer sr;
    public Animator bird;
    void Start()
    {
        choose = PlayerData.pd.SelectedSkin;
        sr.sprite = sprites[choose];
        bird.runtimeAnimatorController = animators[choose];
    }

}
