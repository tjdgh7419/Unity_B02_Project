using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public AudioClip flip;
    public AudioSource audioSource;
    public Animator anim;

    //private bool isTimeOver = false; > �ð� �ʰ� ���θ� Ȯ���ϴ� �÷���

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openCard()
    {
		audioSource.PlayOneShot(flip);
		anim.SetBool("isOpen", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);

        if(gameManager.I.firstCard == null)
        {
            gameManager.I.firstCard = gameObject;
        }
        else
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatched();
        }
    }

    //public void SetTimeOver() >> �ð��� �ʰ��Ǿ����� ���� �ż���
    //{
       // isTimeOver = true; 
    //}
    public void destroyCard()
	{
		Invoke("destroyCardInvoke", 1.0f);
	}

	void destroyCardInvoke()
	{
		Destroy(gameObject);
	}

	public void closeCard()
	{
		Invoke("closeCardInvoke", 1.0f);
	}

	void closeCardInvoke()
	{
		anim.SetBool("isOpen", false);
		transform.Find("back").gameObject.SetActive(true);
		transform.Find("front").gameObject.SetActive(false);
	}
}
