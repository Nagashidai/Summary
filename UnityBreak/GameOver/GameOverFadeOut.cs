using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverFadeOut : MonoBehaviour {
  float red=0, green=0, blue=0,alfa=0,tmp=0; 
  Image fadeImage;
  bool flag=false;
  void Start () {
    fadeImage = GameObject.Find("GameOverPanel").GetComponent<Image>();    
    red = fadeImage.color.r;
    green = fadeImage.color.g;
    blue = fadeImage.color.b;
    alfa = fadeImage.color.a;
  }

  public void Flag(){
    tmp = 0.1f;
  }
  public void FadeOut(){
      alfa +=0.02f;
      fadeImage.color = new Color(red,green,blue,alfa);
  }

 
  void Update () {
    alfa = fadeImage.color.a;
    if(tmp>0)FadeOut();
    if(alfa>=1 && tmp>0){
      StartCoroutine(Change());
    }
  }

  private IEnumerator　Change(){
    yield return new WaitForSeconds(2.0f);
    if(transform.name=="OneMore"){
      SceneManager.LoadScene("Game");
    }else{
      SceneManager.LoadScene("Title");
    }
  }
}
