using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour {

	void Start () {

	}
	
	void Update () {
    GetComponent<Text>().text = "WAVE" + StaticVar.WAVE.ToString();		
	}
}
