using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CashStoreScript : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Player.Instance.playerData.isFirstStart)
        {
            SoundManager.Instance.clickAudioSource.Play();
            UIManager.Instance.ClickOpenCashStoreUI();
        }
            
    }
}
