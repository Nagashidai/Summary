using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseSlide : MonoBehaviour {

	GameObject player;
  GameObject course;
  GameObject course2;
  GameObject holeCourse;
  GameObject holeCourse2;
  Vector3 pos;
  string strName;
  public int border;
  public System.Random rnd = new System.Random();

	void Start () {
    border = 10;
		player = GameObject.Find("unitychan");
    course = GameObject.Find("Course");
    course2 = GameObject.Find("Course2");
    holeCourse = GameObject.Find("HoleCourse");
    holeCourse2 = GameObject.Find("HoleCourse2");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.z > border){
      Slide();
    }
	}

  
  void Slide(){
   if(holeCourse2.transform.position.z < border){
      border += 10;
      pos = holeCourse2.transform.position;
      pos.z += 220f;
      holeCourse2.transform.position = pos;
      SpornCenter();
    }else if(course2.transform.position.z < border){
      border += 100;
      pos = transform.position;
      pos.z += 220f;
      transform.position = pos;
    }else if(holeCourse.transform.position.z < border){
      border += 10;
      pos = holeCourse.transform.position;
      pos.z += 220f;
      holeCourse.transform.position = pos;
      SpornLeft();
    }else if(course.transform.position.z < border){
      border += 100;
      pos = course.transform.position;
      pos.z += 220f;
      course.transform.position = pos;
    }
  }

  
  /*coinsはx=5.08で真ん中
    coinsはx=1.50で左
    coinsはx=8.66で右
    coinsはy=3.89で高さOK*/
  void SpornLeft(){
    Vector3 coinsPos = new Vector3(1.50f,3.89f,pos.z+5);
    GameObject holeCoins = (GameObject)Resources.Load("coins");
    Instantiate(holeCoins,coinsPos,Quaternion.identity);
  }

  void SpornCenter(){
    Vector3 coinsPos = new Vector3(5.08f,3.89f,pos.z+5);
    GameObject holeCoins = (GameObject)Resources.Load("coins");
    Instantiate(holeCoins,coinsPos,Quaternion.identity);
  }

   void SpornBothEnd(){
    Vector3 coinsPos = new Vector3(1.42f,3.89f,pos.z+5);
    GameObject holeCoins = (GameObject)Resources.Load("coinsFive");
    Instantiate(holeCoins,coinsPos,Quaternion.identity);
    coinsPos = new Vector3(8.39f,3.89f,pos.z+5);
    holeCoins = (GameObject)Resources.Load("coinsFive");
    Instantiate(holeCoins,coinsPos,Quaternion.identity);
  }

}
