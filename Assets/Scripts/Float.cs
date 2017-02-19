using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace com.kreweofvaporwave.parade {
	public class Float : Photon.MonoBehaviour {
		public Transform target;
		public GameObject throws;

		public float throwForce = 4;
		public float throwInterval = 10.0f;
		public float throwDirection = 0;

		NavMeshAgent agent;
			Renderer rend;
		// Use this for initialization
		void Start () {
			rend = GetComponentInChildren<Renderer>();
			target = GameObject.Find("parade end").transform;
			agent = GetComponent<NavMeshAgent>();
			StartCoroutine("Throw");

		}

		// Update is called once per frame
		void Update () {
			agent.SetDestination(target.position);
			if (!agent.pathPending)
			{
				if (agent.remainingDistance <= agent.stoppingDistance)
				{
					if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
					{
						Object.Destroy(this.gameObject);
					}
				}
			}
				
			randomize ();

		}

		IEnumerator Throw () {
			while (true){
				yield return new WaitForSeconds(throwInterval);
				GameObject currentThrow = (GameObject)PhotonNetwork.InstantiateSceneObject(throws.name, new Vector3 (transform.position.x + Random.Range(-7, 7), transform.position.y + 10 + Random.Range(-3, 3), transform.position.z), Quaternion.identity, 0, new object[0]);
				//currentThrow.GetComponent<Rigidbody>().AddForce(Vector3.left * throwForce, ForceMode.Impulse);
				if (throwDirection < .5) {
					currentThrow.GetComponent<Rigidbody> ().AddForce (Vector3.left * throwForce, ForceMode.Impulse);
				} else {
					currentThrow.GetComponent<Rigidbody> ().AddForce (Vector3.right * throwForce, ForceMode.Impulse);
				}
			}
		}

		void randomize () {
			throwForce = (Random.value * 3) + 1;
			throwInterval = (Random.value * 2);
			throwDirection = Random.value;
		}
	}
}