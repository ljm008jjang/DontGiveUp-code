using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkBox : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(UIManager.Instance.TalkBoxFollowPlayer());
    }
}
