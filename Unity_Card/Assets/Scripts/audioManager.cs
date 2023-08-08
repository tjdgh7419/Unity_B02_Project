using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip bgmusic;
    public AudioClip endmusic;
	bool timerChk = false;
	// Start is called before the first frame update
	void Start()
    {
        audioSource.clip = bgmusic;
		audioSource.volume = 0.4f;
		audioSource.Play();
	}
    // Update is called once per frame
    void Update()
    {		
		if(gameManager.I.time >= 20f && !timerChk)
		{
			timerChk = true;
			audioSource.clip = endmusic;
			audioSource.Play();
		}
	}
}
