using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGameOver : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

  public void ChangeGame(){
    StartCoroutine(Wait());
  }

  private IEnumerator　Wait(){
    yield return new WaitForSeconds(3.5f);
    SceneManager.LoadScene("GameOver");
    yield break;
  }
}
