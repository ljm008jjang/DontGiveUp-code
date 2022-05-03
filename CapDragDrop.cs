using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CapDragDrop : MonoBehaviour//, IDropHandler
{
    /*
    Player player;
    ItemManager itemManager;

    private void Start()
    {
        player = Player.Instance;
        itemManager = ItemManager.Instance;
    }

    public void OnDrop(PointerEventData eventData)
    {
        DragDrop dD = eventData.pointerDrag.GetComponent<DragDrop>();
        Cap cap = null;
        if (itemManager.Inventory[dD.index][0]!=null)
        cap = itemManager.Inventory[dD.index][0].GetComponent<Cap>();
        

        if (dD != null && cap != null)
        {
            Sprite tmp;
            Image dragImg = eventData.pointerDrag.GetComponentsInChildren<Image>()[1];
            Image destinationImg = GetComponentsInChildren<Image>()[1];


            tmp = dragImg.sprite;

            dragImg.sprite = destinationImg.sprite;
            destinationImg.sprite = tmp;



            if(player.capItem != null)//플레이어 모자 O
            {
                if (player.capItem.itemName == "CapY")
                {
                    itemManager.SetItem(dD.index, 0, ItemDB.Instance.CapYPrefab);
                   // player.capAnimator.SetBool("isYellow", false);
                }
                else if (player.capItem.itemName == "CapO")
                {
                    itemManager.SetItem(dD.index, 0, ItemDB.Instance.CapOPrefab);
                   // player.capAnimator.SetBool("isOrange", false);
                }
                else if (player.capItem.itemName == "CapR")
                {
                    itemManager.SetItem(dD.index, 0, ItemDB.Instance.CapRPrefab);
                    //player.capAnimator.SetBool("isOrange", false);
                }
            }
            else//플레이어 모자 x
            {
                itemManager.Inventory[dD.index].RemoveAt(0);
                itemManager.Inventory[dD.index].Add(null);
            }

            
            player.capItem = cap;
            player.capObject.GetComponent<SpriteRenderer>().sprite = player.capItem.itemImage;
            
            if (player.capItem.itemName == "CapY")
            {
                player.capAnimator.SetBool("isYellow", true);
            }
            else if (player.capItem.itemName == "CapO")
            {
                player.capAnimator.SetBool("isOrange", true);
            }
                
            
            UIManager.Instance.UpdateStoreInventoryUI();
        }
    }
    
    public void TakeOffCap()
    {
        if(player.capItem != null)
        {
            Image destinationImg = GetComponentsInChildren<Image>()[1];

            destinationImg.sprite = null;
            
            Item IT = player.capItem;
            itemManager.AddItem(IT);
            player.capItem = null;

            UIManager.Instance.UpdateStoreInventoryUI();

            
            if (player.capItem.itemName == "CapY")
            {
                itemManager.AddItem(ItemDB.Instance.CapYPrefab);
                player.capItem = null;          
            }
            
        }
        
    }
    */
}
