using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using Unity.Collections.LowLevel.Unsafe;

public class gameManager : MonoBehaviour
{
	public float maxTime = 60f;
	public float currentTime;

    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioSource audioSource;
	public GameObject endTxt;
	public GameObject firstCard;
	public GameObject secondCard;
    public GameObject card;
    public Text timeTxt;
	public static gameManager I;
	public bool isMatching;
    public float time;
    public Text scoreTxt;
    public float score;

	void Awake()
//>>>>>>> color_test
	{
		I = this;
	}
	// Start is called before the first frame update
	void Start()
	{
        currentTime = maxTime;
        isMatching = false;
        UpdateTimeText();

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
//<<<<<<< HEAD

    } 
	void Update()
	{
        {

            scoreTxt.text = score.ToString("");
            if (Input.GetMouseButtonDown(0))
            {
                score += 1;
            }
        }

        if (!isMatching)
		{

			if (currentTime > 0f)
			{
				currentTime -= Time.deltaTime;
				UpdateTimeText();
			}
			else
			{
				// �ð��� �� �Ǹ� ���� ���� ó��
				GameOver();
			}
		}
	}
    private void UpdateTimeText()
    {
        timeTxt.text = Mathf.Ceil(currentTime).ToString();
    }


    public void isMatched()
	{
		string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
		string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

		if (firstCardImage == secondCardImage) 
		{
            audioSource.PlayOneShot(correctSound); //�������� ���� �߰�
            firstCard.GetComponent<card>().destroyCard();
			secondCard.GetComponent<card>().destroyCard();

			int cardsLeft = GameObject.Find("cards").transform.childCount;

			if(cardsLeft == 2)
			{
				Time.timeScale = 0f;
				endTxt.SetActive(true);
			}
		}

		else
		{
            audioSource.PlayOneShot(incorrectSound);
            firstCard.transform.Find("back").GetComponent<SpriteRenderer>().color = Color.gray;
			secondCard.transform.Find("back").GetComponent<SpriteRenderer>().color = Color.gray;
            FailMatch();
  
            firstCard.GetComponent<card>().closeCard();

		}

		firstCard = null;
		secondCard = null;
	}

    public void FailMatch() 
    {
        isMatching = true;
        currentTime -= 3f;
        if (currentTime < 0f)
        {
            currentTime = 0f;
		}
		UpdateTimeText();
		isMatching = false;
    }



	public void GameOver()
    {
		endTxt.gameObject.SetActive(true);

    }

}
