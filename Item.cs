using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType  // 아이템 유형
{
    Equipment,
    Usable,
    Mineral,
    ETC,
}

//[CreateAssetMenu(fileName = "Scriptable Object", menuName = "Scriptable Object/Item")]
[System.Serializable]
public class Item : MonoBehaviour
{
    
    public string itemName;
    public ItemType itemType; // 아이템 유형
    public Sprite itemImage; // 아이템의 이미지(인벤 토리 안에서 띄울)
    public int price;
    /*
    protected virtual void Awake()
    {
        itemImage = gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    */
    //public GameObject itemPrefab;  // 아이템의 프리팹 (아이템 생성시 프리팹으로 찍어냄)
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)//광물일때만 작동함
    {
        if (collision.gameObject.layer.Equals(10))
        {
            GetItem();
        }
    }

    protected virtual void GetItem()
    {
        ItemManager.Instance.AddItem(ItemDB.Instance.itemDictionary[this.itemName]);
        gameObject.SetActive(false);
        SoundManager.Instance.mineralAudioSource.Play();
    }
    
}
