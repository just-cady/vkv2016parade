using UnityEngine;
using System.Collections;

namespace com.kreweofvaporwave.parade
{
	public class AgentSpawner_VKV : MonoBehaviour {

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
			if (PhotonNetwork.isMasterClient){
	        	StartCoroutine(Spawn());
			}
			else {
				Debug.Log("not master");
			}
		}

	    IEnumerator Spawn()
	    {
	        yield return new WaitForSeconds(spawnInterval);

			m_waypointManager.AddEntity((GameObject)PhotonNetwork.Instantiate(m_agentPrefab.name, m_spawnPoint.position, Quaternion.identity, 0));

	        if (m_spawned++ < m_amountToSpawn - 1 | m_infinite)
	            StartCoroutine(Spawn());
	    }

	}
}