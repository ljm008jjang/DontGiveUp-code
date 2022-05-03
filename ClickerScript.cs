using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerScript : MonoBehaviour, IPointerClickHandler//UI상에 있는 클리커를 클릭시 작동함수를 실행하는 스크립트
{
    private static ClickerScript _Instance;
    public static ClickerScript Instance
    {
        get
        {
            return _Instance;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Player.Instance.playerData.isFirstStart)
        {
            SoundManager.Instance.clickAudioSource.Play();
            UIManager.Instance.ClickOpenClickerUI();
        }
            
    }

    [SerializeField]
    Image ClickerImage;

    private void Awake()
    {
        _Instance = this;
    }

    public IEnumerator ChangeColor()
    {
        int speed = 1;

        bool isRed = false;

        while (ClickerManager.Instance.mineralNum >= ClickerManager.Instance.maxMineralCapacity)
       {


            if (!isRed)
            {
                ClickerImage.color = Color.Lerp(ClickerImage.color, Color.red, Time.deltaTime * speed);
                
                if (ClickerImage.color.g<0.3f)
                {
                    isRed = true;
                }
            }
            else
            {
                ClickerImage.color = Color.Lerp(ClickerImage.color, Color.white, Time.deltaTime * speed);

                if (ClickerImage.color.g>0.7f)
                {
                    isRed = false;
                }
            }
            

           
            yield return null;
       }

        ClickerImage.color = Color.white;
    }
}
