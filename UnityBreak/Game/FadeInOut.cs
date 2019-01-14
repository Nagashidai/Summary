using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {
  public float red=0, green=0, blue=0,alfa=0; 
  bool isFadeIn = true;
  public Image fadeImage;
  int i;
  public WallDestroy destroy;

	// Use this for initialization
	void Start () {
		fadeImage = GetComponent<Image>();
    destroy = GameObject.Find("Wall").GetComponent<WallDestroy>();
    red = fadeImage.color.r;
    green = fadeImage.color.g;
    blue = fadeImage.color.b;
    alfa = fadeImage.color.a;
	}
	
	// Update is called once per frame
	void Update () {
    alfa = fadeImage.color.a;
    if(isFadeIn){FadeIn();if(alfa<=0){isFadeIn=false;}}
    if(destroy.flag==1){FadeOut();}
	}

  public void FadeOut(){
      alfa +=0.01f;
      fadeImage.color = new Color(red,green,blue,alfa);
      if(alfa>=1){
        destroy.flag=0;
      }
  }

  public void FadeIn(){
      alfa -=0.02f;
      fadeImage.color = new Color(red,green,blue,alfa);
      if(alfa>=1){
        destroy.flag=0;
      }
  }
}
