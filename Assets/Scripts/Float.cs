using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace com.kreweofvaporwave.parade {
	public class Float : MonoBehaviour {
		public Transform target;
		NavMeshAgent agent;
			Renderer rend;
		// Use this for initialization
		void Start () {
			rend = GetComponentInChildren<Renderer>();
			target = GameObject.Find("parade end").transform;
			agent = GetComponent<NavMeshAgent>();

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
	}
}