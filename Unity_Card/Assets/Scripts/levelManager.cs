using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelBtn : MonoBehaviour
{
	int i = 0;
	public Text levelTxt;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void EasyStart()
	{
		PlayerPrefs.SetInt("level", 1);
	}

	public void NormalStart()
	{
		PlayerPrefs.SetInt("level", 2);
	}

	public void HardStart()
	{ 
		PlayerPrefs.SetInt("level", 3);
	}
}
