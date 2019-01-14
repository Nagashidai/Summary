using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUnitychan : MonoBehaviour {
  string key = "HIGH SCORE";
  int i=0;
  private const string key_isWait = "isWait";
  private const string key_isWait2 = "isWait2";
  private const string key_isWait3 = "isWait3";
  private const string key_isWait4 = "isWait4";
  private const string key_isWait5 = "isWait5";
  private string[] src = {key_isWait,key_isWait2,key_isWait3,
                                    key_isWait4,key_isWait5};
  Animator anime;


	void Start () {
    GameObject.Find("HIGH SCORE").GetComponent<Text>().text 
                     = PlayerPrefs.GetInt(key,0).ToString();
	  anime = GetComponent<Animator>();
	}
	
  void Update() {
    for(i=0;i<5;i++){
      //yield return new WaitForSeconds(1.0f);
      anime.SetBool(src[i],true);  
    }      
	}
}
