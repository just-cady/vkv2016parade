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
				

		}

		IEnumerator Throw () {
			while (true){
				yield return new WaitForSeconds(throwInterval);
				GameObject currentThrow = (GameObject)PhotonNetwork.InstantiateSceneObject(throws.name, new Vector3 (transform.position.x, transform.position.y + 10, transform.position.z), Quaternion.identity, 0, new object[0]);
				currentThrow.GetComponent<Rigidbody>().AddForce(Vector3.left * throwForce, ForceMode.Impulse);
			}
		}
	}
}