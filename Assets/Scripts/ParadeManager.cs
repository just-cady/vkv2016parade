using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.kreweofvaporwave.parade
{
	public class ParadeManager : Photon.MonoBehaviour {
		public GameObject[] floats;
		public float SecondsToWait = 120.0f;
		//public int numberOfFloats = 1;
		//public float spawnInterval = 10.0f;
		public Transform m_spawnPoint;
		private int count = 0;

		// Use this for initialization
		void Start () {
			m_spawnPoint = GameObject.Find("spawn point").transform;
			//floats = new string[numberOfFloats];
			//floats[0] = "Float1";

			//GetComponent<PhotonView>().RPC("RPCSpawn", PhotonTargets.All, numberOfFloats, spawnInterval);
			StartCoroutine("Spawn");

		}
		
		IEnumerator Spawn()
		{
			while (true){
				Debug.Log("before");
				PhotonNetwork.InstantiateSceneObject(floats[count].name, m_spawnPoint.position, Quaternion.identity, 0, new object[0]);
				yield return new WaitForSeconds(SecondsToWait);
				Debug.Log("after");
				count = (count + 1) % floats.Length;
					/*floatCount++;

					if (floatCount == numberOfFloats){
						floatCount = 0;
					} */
			}
		}

		/*[PunRPC]
		void RPCSpawn(int numberOfFloats, float spawnInterval)
		{
			StartCoroutine(Spawn(numberOfFloats, spawnInterval));
		}*/
	}
}
