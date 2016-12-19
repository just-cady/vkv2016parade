using UnityEngine;
using System.Collections;

namespace com.kreweofvaporwave.parade
{
	public class AgentSpawner_VKV : Photon.MonoBehaviour {

	    public GameObject m_agentPrefab;
	    public int m_amountToSpawn;
	    protected WaypointManager m_waypointManager;
	    public float spawnInterval = 1.25f;
	    protected int m_spawned = 0;
	    public Transform m_spawnPoint;
	    public bool m_infinite = false;

		// Use this for initialization
		void Start () {
	        m_waypointManager = GetComponent<WaypointManager>();
			m_spawnPoint = GameObject.Find("Waypoint Spawn Point").transform;

			if (PhotonNetwork.isMasterClient){
				GetComponent<PhotonView>().RPC("RPCSpawn", PhotonTargets.All);
			}
			else {
				Debug.Log("not master");
			}
		}

	    IEnumerator Spawn()
	    {
	        yield return new WaitForSeconds(spawnInterval);

			m_waypointManager.AddEntity((GameObject)PhotonNetwork.InstantiateSceneObject(m_agentPrefab.name, m_spawnPoint.position, Quaternion.identity, 0, new object[0]));

	        if (m_spawned++ < m_amountToSpawn - 1 | m_infinite)
	            StartCoroutine(Spawn());
	    }

		[PunRPC]
		void RPCSpawn()
		{
			StartCoroutine(Spawn());
		}

	}
}
