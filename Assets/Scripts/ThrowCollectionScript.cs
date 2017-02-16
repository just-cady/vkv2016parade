using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCollectionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log("collided");
		if (collision.gameObject.tag == "Throw"){
			collision.gameObject.GetComponent<PhotonView>().RequestOwnership();
			ThrowAssignmentScript tas = collision.gameObject.GetComponent<ThrowAssignmentScript>();
			int throwID = tas.throwID;
			Debug.Log(PlayerPrefs.GetString("PlayerEmail"));
			Debug.Log(throwID);
			PhotonNetwork.Destroy(collision.gameObject);
		}
	}
}
