using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCollectionScript : MonoBehaviour {

	private int throwNum = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log("collided");
		if (collision.gameObject.tag == "Throw"){
			collision.gameObject.GetComponent<PhotonView>().RequestOwnership();
			//ThrowAssignmentScript tas = collision.gameObject.GetComponent<ThrowAssignmentScript>();
			//int throwID = tas.throwID;
			throwNum = throwNum + 1;
			Debug.Log(PlayerPrefs.GetString("PlayerEmail"));
			Debug.Log(throwNum);
			Post ();

			PhotonNetwork.Destroy(collision.gameObject);
		}
	}

	void Post () {
		string url = "http://notnatural.co/vkv/post2log.php";

		WWWForm form = new WWWForm ();
		form.AddField ("address", PlayerPrefs.GetString ("PlayerEmail"));
		form.AddField ("number", throwNum);
		WWW www = new WWW (url, form);
	}
}
