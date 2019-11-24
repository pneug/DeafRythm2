using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    public static List<AnimationManager> anims = new List<AnimationManager>();

    public Sprite[] sprites;
    private int frame = 0;

    private Image image;

    private void Awake()
    {
        anims.Add(this);
        image = GetComponent<Image>();
        

    }

    private void Start()
    {
        //image = GetComponent<Image>();
    }

    public void OnBeat()
    {
        print(frame);
        image.sprite = sprites[frame];
        frame = (frame + 1) % sprites.Length;
    }
}
