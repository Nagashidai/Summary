using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class UnitychanAnimation : MonoBehaviour {

	private Animator anima;
  private UnityVoice voice;
  public bool Fall = false;

	//設定したフラグの名前
	private const string key_isRun = "isRun";
	private const string key_isRunRight = "isRunRight";
  private const string key_isRunLeft = "isRunLeft";
  private const string key_isJump = "isJump";
  private bool bl = false;
  private bool tmp = true;
  private int hoge =0;

	void Start () {
		anima = GetComponent<Animator>();
    voice = GetComponent<UnityVoice>();
    StartCoroutine(loop());
	}
	
	void Update () {
    if(CrossPlatformInputManager.GetAxis("Vertical")>0.6){ 
      Jump();
    }else{
      anima.SetBool(key_isJump,false);
    }

    if(CrossPlatformInputManager.GetAxis("Horizontal")>0){
      //RunからRunRightに遷移する
      anima.SetBool(key_isRunRight,true);
    }else{
      //RunRightからRunに遷移する
      anima.SetBool(key_isRunRight,false);
    }

    if(CrossPlatformInputManager.GetAxis("Horizontal")<0){
      //RunからRunLeftに遷移する
      anima.SetBool(key_isRunLeft,true);
    }else{
      //RunLeftからRunに遷移する
      anima.SetBool(key_isRunLeft,false);
    }

	}

  void Jump(){
      //一度だけ呼ばれる
    if(Fall==false){
      tmp = anima.GetCurrentAnimatorStateInfo(0).IsName("Jump");
      if(transform.position.y==0 && tmp==false && hoge==0){
        Debug.Log("よばれた");
        voice.JumpVoice();
        anima.SetBool(key_isJump,true);
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0.0f,7.15f,0.0f);
        rb.AddForce(force, ForceMode.Impulse);
        hoge=1;
      }
    }
  }

  private IEnumerator loop(){
    while(true){
      yield return new WaitForSeconds(2f);
      hoge=0;
    }
  }

}
