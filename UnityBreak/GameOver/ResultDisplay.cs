using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI.Image;

public class ResultDisplay : MonoBehaviour {
	// Use this for initialization
  public static int highScore;
  string key = "HIGH SCORE";
  float red=1, green=1, blue=1,alfa=1;
  public AudioSource[] audio;
  public AudioSource sound01;
  public AudioSource sound02;
  int i=0;
  Image img;
  Image img2;
  Image img3;
  Image img4;
  Text text;
  Text text2;
  Text text3;
  Text text4;
  Image img5;
  Image img6;
	void Start () {
    audio = GameObject.Find("unitychan").GetComponents<AudioSource>();
    sound01 = audio[0];
    sound02 = audio[1];
    img = GameObject.Find("WAVE").GetComponent<Image>();
    img2 = GameObject.Find("WALL").GetComponent<Image>();
    img3 = GameObject.Find("COIN").GetComponent<Image>();
    img4 = GameObject.Find("SCORE").GetComponent<Image>();
    text = GameObject.Find("WaveText").GetComponent<Text>();
    text2 = GameObject.Find("WallText").GetComponent<Text>();
    text3 = GameObject.Find("CoinText").GetComponent<Text>();
    text4 = GameObject.Find("ScoreText").GetComponent<Text>();
    img5 = GameObject.Find("TitlePanel").GetComponent<Image>();;
    img6 = GameObject.Find("OneMoreTitle").GetComponent<Image>();;

	  text.text = StaticVar.WAVE.ToString();
    text2.text = StaticVar.WALL.ToString();
    text3.text = StaticVar.COIN.ToString();
    text4.text = StaticVar.SCORE.ToString();
    if(StaticVar.SCORE>highScore){
      highScore = StaticVar.SCORE;
      PlayerPrefs.SetInt(key, highScore);     
    }
	}
	
	// Update is called once per frame
	void Update () {
   StartCoroutine(DisplayResult());
	}

  private IEnumerator　DisplayResult(){
    yield return new WaitForSeconds(2.00f);
    if(i==0){
      sound01.PlayOneShot(sound01.clip);i++;
    }
    img.color = new Color(red,green,blue,alfa);
    img2.color = new Color(red,green,blue,alfa);
    img3.color = new Color(red,green,blue,alfa);
    img4.color = new Color(red,green,blue,alfa);
    yield return new WaitForSeconds(1.00f);
    if(i==1){
      sound01.PlayOneShot(sound01.clip);i++;
    }
    text.color = new Color(red,green,blue,alfa);
    text2.color = new Color(red,green,blue,alfa);
    text3.color = new Color(red,green,blue,alfa);
    yield return new WaitForSeconds(1.00f);
    if(i==2){
      sound02.PlayOneShot(sound02.clip);i++;
      if(StaticVar.SCORE < 100){
        yield return new WaitForSeconds(0.30f);
        sound02 = audio[2];
        sound02.PlayOneShot(sound02.clip);
      }else if(StaticVar.SCORE < 5000 && StaticVar.SCORE > 100){
        yield return new WaitForSeconds(0.30f);
        sound02 = audio[3];
        sound02.PlayOneShot(sound02.clip);
      }else{
        yield return new WaitForSeconds(0.30f);
        sound02 = audio[4];
        sound02.PlayOneShot(sound02.clip);
      }
    }
    text4.color = new Color(red,green,blue,alfa);
    img5.color = new Color(red,green,blue,alfa);
    img6.color = new Color(red,green,blue,alfa);
  }
}
