using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip bgmusic;
    public AudioClip endmusic;
	// Start is called before the first frame update
	void Start()
    {
        audioSource.clip = bgmusic;
		audioSource.Play();
	}
    // Update is called once per frame
    void Update()
    {		
	}
}
