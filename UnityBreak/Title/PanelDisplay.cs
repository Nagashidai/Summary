using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDisplay : MonoBehaviour {
  float red=1, green=1, blue=1,alfa=0; 
  Image fadeImage;
  int hoge=0;
  int tmp=0;
  int tmp2=0;
	// Use this for initialization
	void Start () {
		fadeImage = GameObject.Find("Panel2").GetComponent<Image>();
	}
	// Update is called once per frame
	void Update () {
    Debug.Log(hoge);
		if(hoge < 20){
      FirstDisplay();
    }else　if(hoge==20){
      if(alfa==1){
         Debug.Log("はつどう");
        for(int i=0;i<20;i++){
          FlashDownDisplay();
        }
      }/*
      if(tmp%20==0){
        for(int i=0;i<20;i++){
          FlashDownDisplay();
        }
      }      
      if(tmp2%20==0){
        for(int k=0;k<20;k++){
          FlashUpDisplay();
        }
      }*/  
    }
	}

  void FirstDisplay(){
    alfa +=0.05f;
    fadeImage.color = new Color(red,green,blue,alfa);
    hoge++;
  }

  void FlashDownDisplay(){
    alfa -=0.01f;
    fadeImage.color = new Color(red,green,blue,alfa);
    tmp++;
  }

  void FlashUpDisplay(){
    alfa +=0.01f;
    fadeImage.color = new Color(red,green,blue,alfa);
    tmp2++;
  }
}
