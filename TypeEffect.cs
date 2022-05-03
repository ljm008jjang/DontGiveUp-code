using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeEffect : MonoBehaviour
{

    public int charPerSeconds;
    public int index;
    string targetMsg;
    public GameObject endCursor;
    public TextMeshProUGUI msgText;

    private void Awake()
    {
        msgText = GetComponent<TextMeshProUGUI>();
    }

    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        endCursor.SetActive(false);
        Invoke("Effecting", 1 / charPerSeconds);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            if (TalkManager.Instance.talkNum == 1)
            {
               TalkManager.Instance.isWalkEnd = true;
            }
          EffectEnd();
          return;
        }

        msgText.text += targetMsg[index];
        index++;

        Invoke("Effecting", 1 / charPerSeconds);
    }

    void EffectEnd()
    {
        if (TalkManager.Instance.isWalkEnd && TalkManager.Instance.talkNum != TalkManager.Instance.talkData.Count)
        {
            endCursor.SetActive(true);
            return;
        }
        else
        {
            endCursor.SetActive(false);
            Invoke("EffectEnd", 0.5f);
        }

    }

    // Update is called once per frame

}
