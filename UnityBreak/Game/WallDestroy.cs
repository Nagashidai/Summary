using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour {
  FadeInOut fade;
  public int flag=0;
  Animator anime;
  private const string key_isFall = "isFall";
  Material mat;
  string materialName;
  public int necessaryCoins,coinNum;
  public UnityVoice voice;
  public UnitychanAnimation unityAnime;
  [HideInInspector]public int destroyWalls=1;
  public PlayerMove move;
  public WaveChange wave;

	void Start () {
    wave = GameObject.Find("WaveChange").GetComponent<WaveChange>();
    move = GameObject.Find("unitychan").GetComponent<PlayerMove>();
    fade = GameObject.Find("FadePanel").GetComponent<FadeInOut>();
		anime = GameObject.Find("unitychan").GetComponent<Animator>();
    voice = GameObject.Find("unitychan").GetComponent<UnityVoice>();
    unityAnime = GameObject.Find("unitychan").GetComponent<UnitychanAnimation>();
	}
	
	void Update () {
		
	}

  void OnCollisionEnter(Collision collision){
    materialName = this.GetComponent<Renderer>().material.name;
    necessaryCoins = int.Parse(materialName.Substring(4,1));
    coinNum = GameObject.Find("CoinSum").GetComponent<CoinSum>().coins;
    if(coinNum>=necessaryCoins){
      Destroy(this.gameObject);
      GameObject.Find("CoinSum").GetComponent<CoinSum>().coins -= necessaryCoins;
      wave.destroyWalls++;
      if(wave.destroyWalls%3==0){move.speed+=2;StaticVar.WAVE++;}
    }else if(coinNum < necessaryCoins){
      unityAnime.Fall = true;
      anime.Play("Fall");
      fade.destroy = this.GetComponent<WallDestroy>();
      flag=1;
    }
    if(collision.gameObject.tag == "Player" && coinNum < necessaryCoins){
      voice.WallCollide();
    }else if(collision.gameObject.tag == "Player"){
      voice.WallVoice();
    }
  }
}
