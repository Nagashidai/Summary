using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerMove : MonoBehaviour {
	Animator animator;
	AnimatorStateInfo stateInfo;
	float a;
	float red=0,green=0,blue=0;
	public Rigidbody rigidbody;
	Vector3 startPos;
	Vector3 worldpositionStart;
	Vector3 pos;
	float disX;
	GameObject obje;
	public WallDestroy waDestroy;
	Camera camera;
	public ChangeGameOver change;
	public UnityVoice voice;
	public int speed=10;
	int i;
	FadeInOut tmp;
  AudioSource audio;
  AudioSource[] audioSources;
  int tanma;

	void Start () {
    tanma = 0;
    audioSources = GetComponents<AudioSource>();
    audio = audioSources[6];
		tmp = GameObject.Find("FadePanel").GetComponent<FadeInOut>();
		waDestroy = GameObject.Find("Wall").GetComponent<WallDestroy>();
		voice = GetComponent<UnityVoice>();
		animator = GetComponent<Animator>();
		GetComponent<Animator>().applyRootMotion = false;
		obje = GameObject.Find("Main Camera");
		camera = obje.GetComponent<Camera>();
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.freezeRotation = true;
		change = GameObject.Find("SceneChange").GetComponent<ChangeGameOver>();
	}
	
	void Update () {
		stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if(stateInfo.nameHash == Animator.StringToHash("Base Layer.Fall")){
			change.ChangeGame();
		}else{
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
	    transform.position += Vector3.right * axis * Time.deltaTime * 8;
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if(transform.position.y < -25){
			for(i=0;i<50;i++){
        if(tanma==0)audio.PlayOneShot(audio.clip);tanma++;
				tmp.alfa += 0.01f;
				tmp.fadeImage.color = new Color(red,green,blue,tmp.alfa);
			}
			GameObject.Find("SceneChange").GetComponent<ChangeGameOver>().
				ChangeGame();
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "money"){
			voice.CoinVoice();
		}
	}

}
