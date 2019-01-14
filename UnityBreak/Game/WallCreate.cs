using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreate : MonoBehaviour {
	GameObject wall;
	Transform wallTrans;
	GameObject player;
	public GameObject money, _obj; 
	public ScoreText sT; //ScoreTextコンポーネントを入れる
	public System.Random rnd = new System.Random(); //Randomクラスを所得する
	public Material[] _material; //変化するマテリアル
	public Material mat;
	float wallDistance,border = 30;
	int wallSum;
	public int i,k,wallBreak=0; string s;
	string str = "wall";
	string wallName;
	float playerZ;
	Collider colli;
	float off;

	void Start () {
		player = GameObject.Find("unitychan");
		money = GameObject.Find("ScoreText");
		sT = money.GetComponent<ScoreText>();
		CreateWall();
	}
	
	void Update () {
		playerZ = player.transform.position.z;
		CreateWall();
	}
	void CreateWall(){
		//wallDistance = rnd.Next(-10,30);
		_material = new Material[9];
		if(playerZ >= border){
			wallBreak=1;
			border+=50;
			wallDistance = playerZ + 50;
			for(i=1;i<4;i++){
				if(i==1){
					off=-0.2f;
				}else if(i==2){
					off=0;
				}else if(i==3){
					off=0.2f;
				}
			  wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
			  wall.tag = "Wall";
			  wallTrans = wall.transform;
			  wallTrans.position = new Vector3((-6.0f+off+i*3.0f),1.5f,wallDistance);
			  wallTrans.eulerAngles = new Vector3(0,180.0f,0);
			  wallTrans.localScale = new Vector3(3.1f,4,1);
			  colli = wall.GetComponent<BoxCollider>();
			  wall.AddComponent<WallDestroy>();

		 	  wallSum = rnd.Next(1,10);
				for(k=1;k<10;k++){
				  if(wallSum == k){
				  	s = k.ToString();
				  	wallName = String.Concat(str,s); 
				    mat = Resources.Load(wallName) as Material;
				    _material[wallSum-1] = mat;
		  		  wall.GetComponent<Renderer>().material = _material[wallSum-1];
				  }
				}
			}
		}	
	}
	
}
