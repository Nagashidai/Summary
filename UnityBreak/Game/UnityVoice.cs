using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityVoice : MonoBehaviour {

  public AudioSource sound01;
  public AudioSource sound02;
  public AudioSource sound03;
  public AudioSource sound04;
  public AudioSource sound05;
  public AudioSource sound06;
  public AudioSource desSound;
  public WallCreate wallCreate;
  public AudioSource[] audioSources;
  public System.Random rnd = new System.Random();
  int tmp;

	void Start () {
    wallCreate = GameObject.Find("Wall").GetComponent<WallCreate>();
    audioSources = GetComponents<AudioSource>();
    sound01 = audioSources[0];//コイン取得SE
    sound02 = audioSources[1];//壁破壊SE
    sound03 = audioSources[2];//破壊成功時セリフ
    sound04 = audioSources[3];//破壊成功時セリフ２
    sound05 = audioSources[4];//破壊失敗時セリフ
    sound06 = audioSources[5];//ジャンプセリフ
	}
	
	void Update () {
    
	}

  public void CoinVoice(){
    sound01.PlayOneShot(sound01.clip);
  }

  public void WallVoice(){
    if(wallCreate.wallBreak == 1){
      Debug.Log("WallVoiceは作動している");
      tmp = rnd.Next(2,4);
      desSound = audioSources[tmp];
      sound02.PlayOneShot(sound02.clip);
      sound03.PlayOneShot(desSound.clip);
      wallCreate.wallBreak=0;
    }
  }

  public void WallCollide(){
    sound02.PlayOneShot(sound02.clip);
    sound05.PlayOneShot(sound05.clip);
  }

  public void JumpVoice(){
    sound06.PlayOneShot(sound06.clip);
  }
}
