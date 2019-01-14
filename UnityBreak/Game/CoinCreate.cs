using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreate : MonoBehaviour {

  int i,x,y,z,temp,coinDistance=3;
  float[] sporn = new float[3]{-2.5f,0.0f,2.5f};
  float time,posZ;
  GameObject player;

  System.Random rnd = new System.Random();
  //Vector3 pos = new Vector3(0,0.5f,0);
	void Start () {
    player = GameObject.Find("unitychan");
    StartCoroutine(Coin());
  }
	
	void Update () {

	}

  private IEnumerator　Coin(){
    while(true){
      yield return new WaitForSeconds(0.75f);
      posZ = player.transform.position.z;
      x = rnd.Next(0,3);
      y = rnd.Next(25,30);
      Vector3 pos = new Vector3(sporn[x],0.8f,posZ+y);
      GameObject coins = (GameObject)Resources.Load("coin");
      Instantiate(coins,pos,Quaternion.identity);
      temp = rnd.Next(0,10);
      if(temp==0){
        for(i=1;i<4;i++){
          yield return new WaitForSeconds(0.2f);
          pos = new Vector3(sporn[x],0.8f,posZ+y+5+(i*coinDistance));
          coins = (GameObject)Resources.Load("coin");
          Instantiate(coins,pos,Quaternion.identity);
        }
      }
    }
  }
  
}
