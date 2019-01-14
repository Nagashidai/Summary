using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour {
  //TitleFadeOut fadeOut;
  public bool flag=false;
  public AudioSource sound01;
	void Start () {
		sound01 = GameObject.Find("unitychan").GetComponent<AudioSource>();
	}
	
	void Update () {
	  if(Input.GetMouseButtonDown(0)){
      StartCoroutine(Wait());
    }

	}

  public void ChangeGameOver(){
    SceneManager.LoadScene("GameOver");
  }

  private IEnumerator　Wait(){
    sound01.PlayOneShot(sound01.clip);
    while(true){
      flag=true;
      yield return new WaitForSeconds(3.0f);
      SceneManager.LoadScene("Game");
    }
  }
}
