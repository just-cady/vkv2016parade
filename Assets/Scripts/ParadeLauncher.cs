using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadeLauncher : MonoBehaviour {

	private bool ParadeStarted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!ParadeStarted) {
			//Debug.Log ("NO PARADE");
			if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.P) && Input.GetKey (KeyCode.S)) {
				//Debug.Log ("Buttons");
				PhotonNetwork.InstantiateSceneObject("Parade Manager", new Vector3(0, 0, 0), Quaternion.identity, 0, new object[0]);
				ParadeStarted = !ParadeStarted;
			}
		}
	}
}
