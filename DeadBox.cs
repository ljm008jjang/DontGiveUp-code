using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBox : MonoBehaviour
{
    public List<Item> itemList;// = new List<Item>(); //플레이어의 아이템이 모두 들어감
    public int gold;

    WaitForSeconds ws = new WaitForSeconds(0.1f);

    private void Start()
    {
        //gameObject.SetActive(false);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(10))
        {
            GameManager.Instance.gold += gold;

            SoundManager.Instance.getDeadBoxAudioSource.Play();

            for (int i = 0; i < itemList.Count; i++)
            {
                ItemManager.Instance.AddItem(itemList[i]);
                if (itemList[i].itemType.Equals(ItemType.Usable))
                {
                    if (itemList[i].itemName.Equals("폭탄")){
                        ItemManager.Instance.bomb++;
                    }
                    else if (itemList[i].itemName.Equals("다이너마이트"))
                    {
                        ItemManager.Instance.dynamite++;
                    }
                    else if (itemList[i].itemName.Equals("구급상자"))
                    {
                        ItemManager.Instance.aidPack++;
                    }
                    else if (itemList[i].itemName.Equals("텔레포트"))
                    {
                        ItemManager.Instance.teleport++;
                    }
                    else if (itemList[i].itemName.Equals("산소캡슐"))
                    {
                        ItemManager.Instance.oxygenCapsule++;
                    }
                    else if (itemList[i].itemName.Equals("원격상점 티켓"))
                    {
                        ItemManager.Instance.storeTicket++;
                    }
                }
            }

            Initialize();

            UIManager.Instance.UpdateGoldText();

            UIManager.Instance.UpdateUsableItemUI();

            gameObject.SetActive(false);
        }
    }

    private void Initialize()
    {
        gold = 0;
        itemList = new List<Item>();
    }

    public IEnumerator DeadBoxOn()
    {
        
        yield return ws;

        gameObject.SetActive(true);
    }
}
