using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TalkManager : MonoBehaviour
{
    private static TalkManager instance;

    public static TalkManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TalkManager>();

                if (instance == null)
                {
                    GameObject container = new GameObject("TalkManager");
                    instance = container.AddComponent<TalkManager>();
                }
            }
            return instance;
        }
    }


    public List<string> talkData;
    public GameObject[] characterUI;
    public int[] characterNum;
    public int talkNum;
    public bool isWalkEnd;
    private Animator friendAnimator;
    private Animator playerAnimator;

    public TypeEffect effect;
    public GameObject player;
    public GameObject friend;
    public GameObject[] UIs;

    private void Awake()
    {
        if (Player.Instance.playerData.isFirstStart)
        {
            for (int i = 0; i < UIs.Length; i++)
            {
                UIs[i].SetActive(false);
            }
        }
        talkData.Add("");
        talkData.Add("하... 귀찮다... 인생...");
        talkData.Add("아무것도 하기 싫다");
        talkData.Add("거리두기 언제 끝나나...");
        talkData.Add("");
        talkData.Add("친구야! 가만히 있으면 아무것도 일어나지 않아");
        talkData.Add("누구...?");
        talkData.Add("난 네 친구지");
        talkData.Add("일단 가서 땅이라도 파봐!!");
        talkData.Add("요즘 세상에 땅판다고 500원이라도 나오겠어?");
        talkData.Add("일단 파보자!");
        talkData.Add("");


    }

    private void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        friendAnimator = friend.GetComponent<Animator>();

        if (Player.Instance.playerData.isFirstStart)
        {
            effect.SetMsg(talkData[talkNum]);
            StartCoroutine("waitASeconds");
            player.transform.position = new Vector2(-25f, 1.5f);
            //임시
            Array.Resize(ref characterUI, talkData.Count);
            Array.Resize(ref characterNum, talkData.Count);

        }
    }

    public void CharacterImage()
    {
        switch (characterNum[talkNum])
        {
            case 0:
                characterUI[0].SetActive(true);
                characterUI[1].SetActive(false);
                break;
            case 1:
                characterUI[0].SetActive(false);
                characterUI[1].SetActive(true);
                break;
            default:
                characterUI[0].SetActive(false);
                characterUI[1].SetActive(false);
                break;
        }
    }

    public IEnumerator FadeOutFriend()
    {
        var image = friend.GetComponent<SpriteRenderer>();
        if (image.color.a >= 0.99f)
        {
            while (image.color.a > 0)
            {
                effect.endCursor.SetActive(false);
                image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.01f);
                yield return null;
            }
        }
        if (image.color.a <= 0.1f)
        {
            for (int i = 0; i < UIs.Length; i++)
            {
                UIs[i].SetActive(true);
            }
            //Player.Instance.playerData.isFirstStart = false; 확인 누르면 바뀌게 하기


            MoveCharacter();

            UIManager.Instance.OpenTutorialPanel();
            

            this.gameObject.SetActive(false);
        }
        

    }

    IEnumerator waitASeconds()
    {
        yield return new WaitForSeconds(1f);
        ClickButton();
    }

    private void Update()
    {
        if (Player.Instance.playerData.isFirstStart)
        {
            MoveCharacter(); 
        }
        else
        {

            Destroy(this.gameObject);
            Destroy(friend);
        }

    }

    public void ClickButton()
    {
        if (Player.Instance.playerData.isFirstStart)
        {
            talkNum++;
            if (talkNum == talkData.Count)
            {
                //for (int i = 0; i < UIs.Length; i++)
                //{
                //    UIs[i].SetActive(true);
                //}
                //Player.Instance.playerData.isFirstStart = false;
                //MoveCharacter();
                effect.endCursor.SetActive(false);
                StartCoroutine("FadeOutFriend");
                return;
            }
            effect.SetMsg(talkData[talkNum]);
            CharacterImage();
        }
    }

    public void CalcPosition(float positionx, float targetx)
    {
        if (targetx <= positionx + 0.01f && targetx >= positionx - 0.01f)
        {
            isWalkEnd = true;
            ClickButton();
        }
        else
            isWalkEnd = false;
    }
    public void MoveCharacter()
    {

        switch (talkNum)
        {
            case 1:
                friend.transform.position = new Vector3(-5f, 1.5f, 0f);
                break;
            case 4:
                friendAnimator.SetBool("isWalk", !isWalkEnd);
                friend.transform.position = Vector3.MoveTowards(friend.transform.position, new Vector3(-19f, 1.5f, 0f), Time.deltaTime * 3f);
                friend.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                CalcPosition(friend.transform.position.x, -19f);
                break;
            case 5:
                friendAnimator.SetBool("isWalk", !isWalkEnd);
                break;
            case 11:
                //CalcPosition(player.transform.position.x, 0f);
                playerAnimator.SetBool("isWalk", !isWalkEnd);
                friendAnimator.SetBool("isWalk", !isWalkEnd);
                friend.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
                friend.transform.position = Vector3.MoveTowards(friend.transform.position, new Vector3(8.5f, 1.5f, 0f), Time.deltaTime * 3f);
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(2.0f, 1.5f, 0f), Time.deltaTime * 3f);
                CalcPosition(player.transform.position.x, 2.0f);
                break;
            case 12:
                playerAnimator.SetBool("isWalk", !isWalkEnd);
                friendAnimator.SetBool("isWalk", !isWalkEnd);

                break;
            default:
                break;
        }
    }

    public void Cinematic()
    {

    }


}
