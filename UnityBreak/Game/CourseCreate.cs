using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseCreate : MonoBehaviour {

  GameObject player;
  GameObject course;
  GameObject course2;

  int distance30=30,distance60=60,distance30Num=1,distance60Num=1,temp=1;
  float playerZ;
	void Start () {
		player = GameObject.Find("unitychan");
    course = GameObject.Find("Course");
    course2 = GameObject.Find("Course2");
	}
	
	void Update () {
    course.transform.Translate(0,0,0.15f);
	}
}
