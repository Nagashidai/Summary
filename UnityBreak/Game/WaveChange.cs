using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveChange : MonoBehaviour {
  public int destroyWalls=0;
	void Start () {
		
	}
	
	void Update () {
		StaticVar.WALL = destroyWalls;
	}
}
