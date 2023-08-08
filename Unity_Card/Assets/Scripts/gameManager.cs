using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{
	public GameObject nameTxt;
	public Text nameTxt_name;
	public AudioClip match;
	public AudioSource audioSource;
	public GameObject endTxt;
	public GameObject firstCard;
	public GameObject secondCard;
    public GameObject card;
    public Text timeTxt;
    public float time;
	public static gameManager I;
	bool nameChk = false;
	float curTime = 0;

	void Awake()
	{
		I = this;
	}
	// Start is called before the first frame update
	void Start()
	{
		Time.timeScale = 1.0f;
		int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

		rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

		for (int i = 0; i < 16; i++)
		{
			GameObject newCard = Instantiate(card);
			newCard.transform.parent = GameObject.Find("cards").transform;

			float x = (i / 4) * 1.4f - 2.1f;
			float y = (i % 4) * 1.4f - 3.0f;
			newCard.transform.position = new Vector3(x, y, 0);

			string rtanName = "rtan" + rtans[i].ToString();
			newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
		}
    } 

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
		if(time >= 30f)
		{
			endTxt.SetActive(true);
			Time.timeScale = 0f;

		}

		if (nameChk && (curTime + 1f < time))
		{
			nameTxt.SetActive(false);
		}
    }

	public void isMatched()
	{
		string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
		string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
		
		if (firstCardImage == secondCardImage) 
		{
			audioSource.PlayOneShot(match);
			firstCard.GetComponent<card>().destroyCard();
			secondCard.GetComponent<card>().destroyCard();

			if (firstCardImage[4] - '0' >= 0 && firstCardImage[4] - '0' < 3) 
			{
				nameTxt_name.text = "강성호";
				nameChk = true;
				curTime = time;
				nameTxt.SetActive(true);
			}
			else if (firstCardImage[4] - '0' >= 3 && firstCardImage[4] - '0' < 6)
			{
				nameTxt_name.text = "박정우";
				nameChk = true;
				curTime = time;
				nameTxt.SetActive(true);
			}
			else if (firstCardImage[4] - '0' >= 6 && firstCardImage[4] - '0' < 9)
			{
				nameTxt_name.text = "박종수";
				nameChk = true;
				curTime = time;
				nameTxt.SetActive(true);
			}

			int cardsLeft = GameObject.Find("cards").transform.childCount;
			if(cardsLeft == 2)
			{
				Time.timeScale = 0f;
				endTxt.SetActive(true);
			}
		}
		else
		{
			firstCard.GetComponent <card>().closeCard();
			secondCard.GetComponent<card>().closeCard();
		}

		firstCard = null;
		secondCard = null;
	}

	public void retryGame()
	{
		SceneManager.LoadScene("MainScene");
	}

}
