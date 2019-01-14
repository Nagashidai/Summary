using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFadeOut : MonoBehaviour {
  float red=0, green=0, blue=0,alfa=0; 
  Image fadeImage;
  SceneChange scene;
  int tmp=0;
  bool first=true;
  void Start () {
    scene = GameObject.Find("ChangeObject").GetComponent<SceneChange>();
    fadeImage = GetComponent<Image>();
    red = fadeImage.color.r;
    green = fadeImage.color.g;
    blue = fadeImage.color.b;
    alfa = fadeImage.color.a;
  }

  public float FadeIn(){
    alfa +=0.02f;
    fadeImage.color = new Color(red,green,blue,alfa);
    return alfa;
  }
  
  void Update () {
    if(tmp < 49){
      alfa -=0.02f;
      fadeImage.color = new Color(red,green,blue,alfa);
      tmp++;
    }
    if(scene.flag==true){
      FadeIn();
    }
  }
}
