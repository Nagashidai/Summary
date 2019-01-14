using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSum : MonoBehaviour {

	public int coins = 0;
  public int coinsSum = 0;

	void Start () {
		
	}
	
	void Update () {
		StaticVar.COIN = coinsSum;
	}
}
