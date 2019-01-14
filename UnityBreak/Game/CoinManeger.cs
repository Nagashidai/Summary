using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManeger : MonoBehaviour {

	public GameObject obj;
	public CoinSum coinSumSum;
	public int hoge;

	void Start () {
		obj = GameObject.Find("CoinSum");
		coinSumSum = obj.GetComponent<CoinSum>();
	}
	
	void Update () {
		transform.Rotate(new Vector3(0,90,0) * Time.deltaTime * 2);
	}

	void OnCollisionEnter(Collision collision){
		coinSumSum.coins++;
		coinSumSum.coinsSum++;
		Destroy(this.gameObject);
	}
}