using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	public int score;
	public GameObject obj;
	public CoinSum coinSum;
	public RectTransform rectTransform;
	public GameObject unityChan;
	public GameObject obj2;
	public Camera cam;
	public Vector3 set = new Vector3(0.23f,2.0f,0);
	public Vector3 tmp;

	void Start () {
		obj = GameObject.Find("CoinSum");
		coinSum = obj.GetComponent<CoinSum>();

		rectTransform = GetComponent<RectTransform>();
		unityChan = GameObject.FindGameObjectWithTag("Player");
		obj2 = GameObject.Find("Main Camera");
	}
	
	void Update () {
		score = coinSum.coins;
		this.GetComponent<Text>().text = "×"+score.ToString();
	}
}
