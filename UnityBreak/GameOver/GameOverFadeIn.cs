using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverFadeIn : MonoBehaviour {
  public float red=0, green=0, blue=0,alfa=0; 
  Image fadeImage;
	void Start () {
		fadeImage = GetComponent<Image>();
    //GameObject.Find("OneMore").GetComponent<>();
    red = fadeImage.color.r;
    green = fadeImage.color.g;
    blue = fadeImage.color.b;
    alfa = fadeImage.color.a;
	}

  public void FadeIn(){
    alfa -=0.02f;
    fadeImage.color = new Color(red,green,blue,alfa);
  }

 
	void Update () {
		if(alfa>0)FadeIn();
    
	}

  
}
