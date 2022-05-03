using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrillDragDrop : MonoBehaviour//, IDropHandler
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
        Drill drill = null;
        if (itemManager.Inventory[dD.index][0] != null)
            drill = itemManager.Inventory[dD.index][0].GetComponent<Drill>();


        if (dD != null && drill != null)
        {
            Sprite tmp;
            Image dragImg = eventData.pointerDrag.GetComponentsInChildren<Image>()[1];
            Image destinationImg = GetComponentsInChildren<Image>()[1];


            tmp = dragImg.sprite;

            dragImg.sprite = destinationImg.sprite;
            destinationImg.sprite = tmp;



            if (player.drillItem != null)//플레이어 모자 O
            {
                if (player.drillItem.itemName == "DrillY")
                {
                    itemManager.SetItem(dD.index, 0, ItemDB.Instance.drillYPrefab);
                    
                    //player.drillAnimator.SetBool("isYellow", false);
                }
                else if (player.drillItem.itemName == "DrillO")
                {
                    itemManager.SetItem(dD.index, 0, ItemDB.Instance.drillOPrefab);
                    //player.drillAnimator.SetBool("isOrange", false);
                }
                else if (player.drillItem.itemName == "DrillR")
                {
                    itemManager.SetItem(dD.index, 0, ItemDB.Instance.drillRPrefab);
                    //player.capAnimator.SetBool("isOrange", false);
                }
            }
            else//플레이어 모자 x
            {
                itemManager.Inventory[dD.index].RemoveAt(0);
                itemManager.Inventory[dD.index].Add(null);
            }

            player.miningPower = drill.miningPower;
            player.drillItem = drill;
            //player.drillObject.GetComponent<SpriteRenderer>().sprite = player.capItem.itemImage;
            
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

    public void TakeOffDrill()
    {
        if (player.drillItem != null)
        {
            Image destinationImg = GetComponentsInChildren<Image>()[1];

            destinationImg.sprite = null;

            Item IT = player.drillItem;
            itemManager.AddItem(IT);
            player.drillItem = null;

            player.miningPower = 1;

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
