using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
  string key = "HIGH SCORE";
	void Start () {
		this.GetComponent<Text>().text = "HIGH　"+PlayerPrefs.GetInt(key,0).ToString();
	}
	
	void Update () {
    GameObject.Find("CurrentSCORE").GetComponent<Text>().text = StaticVar.SCORE.ToString(); 
	}
}
