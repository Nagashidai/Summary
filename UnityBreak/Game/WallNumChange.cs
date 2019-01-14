using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNumChange : MonoBehaviour {

	GameObject obj;
	public Material mat;
	void Start () {
		obj = GameObject.Find("Wall");
		mat = obj.GetComponent<Renderer>().material;
		Debug.Log(mat);
	}
	
	void Update () {
		
	}
}
