using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVar : MonoBehaviour {
  public static int WAVE=1;
  public static int WALL;
  public static int COIN;
  public static int SCORE;
	void Start () {
		
	}
	
	void Update () {
		SCORE = WAVE*WALL*COIN;
	}
}
