using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoScript : MonoBehaviour {
	public string vidurl = "http://zakberkowitz.com/videos/vkvtestvid.ogv";
	public string audiourl = "http://zakberkowitz.com/sounds/vkvtestaudio.ogg";
	//WWW vidwww;
	//WWW audiowww;
	// Use this for initialization
	void Start () {
		StartCoroutine(PlayMovie(vidurl, audiourl));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator PlayMovie(string vid, string aud){
		WWW vidwww = new WWW(vid);
		WWW audiowww = new WWW(aud);
		MovieTexture movie = vidwww.movie;

		movie.loop = true;
		yield return new WaitUntil(() => movie.isReadyToPlay);

		Renderer rend = GetComponent<Renderer>();
		rend.material.mainTexture = movie;

		AudioClip audClip = audiowww.GetAudioClip(true, true, AudioType.OGGVORBIS);

		Debug.Log(audClip.loadState);

		yield return new WaitUntil(() => audClip.loadState == AudioDataLoadState.Loaded);

		Debug.Log(audClip.loadState);

		AudioSource audSource = GetComponent<AudioSource>();
		audSource.clip = audClip;
		audSource.loop = true;


		movie.Play();
		audSource.Play();
	}
					
}
