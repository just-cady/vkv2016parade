using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAssignmentScript : MonoBehaviour {
	public int throwID = 0;
	// Use this for initialization
	void Start () {
		throwID = UnityEngine.Random.Range(0, 36);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
