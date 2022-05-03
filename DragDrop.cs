using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler, IEndDragHandler, IDragHandler,IDropHandler,IPointerClickHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [SerializeField] private Canvas canvas;

    public int index;

    

    private void Awake()
    {
        index = transform.GetSiblingIndex();
    }
    private void OnEnable()
    {
        if(rectTransform != null)
        {
            rectTransform.anchoredPosition = Vector3.zero;
            rectTransform = null;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;

            Image tmp = UIManager.Instance.introducePanel.GetComponent<Image>();
                tmp.color = 
                new Color(tmp.color.r, tmp.color.g, tmp.color.b,1f);
            rectTransform = null;
            canvasGroup = null;
            transform.SetSiblingIndex(index);
            UIManager.Instance.OffStoreSellPanel();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (rectTransform != null)
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.8f;
            Image tmpi = UIManager.Instance.introducePanel.GetComponent<Image>();
            tmpi.color =
            new Color(tmpi.color.r, tmpi.color.g, tmpi.color.b, 0.8f);
            UIManager.Instance.OnStoreSellPanel();


            if (!ReferenceEquals(ItemManager.Instance.Inventory[index][0], null))
            {
                Item tmp = ItemManager.Instance.Inventory[index][0];

                Sprite sprite = tmp.itemImage;
                string str = tmp.itemName;
                int cost = tmp.price;

                Image img = GetComponentsInChildren<Image>()[1];
                img.maskable = false;

                UIManager.Instance.UpdateIntroducePanel(sprite, str, cost);

                int sell = int.Parse(UIManager.Instance.itemNumText[index].text) * cost;

                UIManager.Instance.UpdateAllSellText(sell);

                UIManager.Instance.ClickOpenUI(UIManager.Instance.introducePanel);
            }
        }
            
        
            
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (rectTransform != null)
        {
            //if (this.gameObject.activeInHierarchy)
                rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            //else
             //   rectTransform.anchoredPosition = Vector3.zero;
        }
            
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<DragDrop>())
        {
            Sprite tmp;
            Image dragImg = eventData.pointerDrag.GetComponentsInChildren<Image>()[1];

            Image destinationImg = GetComponentsInChildren<Image>()[1];

            tmp = dragImg.sprite;

            dragImg.sprite = destinationImg.sprite;
            destinationImg.sprite = tmp;

            TextMeshProUGUI FText = eventData.pointerDrag.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI LText = GetComponentInChildren<TextMeshProUGUI>();
            string tmpS = FText.text;

            FText.text = LText.text;
            LText.text = tmpS;

            if (!ReferenceEquals(eventData.pointerDrag.GetComponent<DragDrop>(), null))
                ItemManager.Instance.SwapItem(eventData.pointerDrag.GetComponent<DragDrop>().index, index);



            transform.SetSiblingIndex(index);
        }
            
        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            Image tmp = UIManager.Instance.introducePanel.GetComponent<Image>();
            tmp.color =
            new Color(tmp.color.r, tmp.color.g, tmp.color.b, 1f);
            Image img = GetComponentsInChildren<Image>()[1];
            img.maskable = true;
            rectTransform = null;
            canvasGroup = null;
            transform.SetSiblingIndex(index);
            UIManager.Instance.OffStoreSellPanel();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        Image img = GetComponentsInChildren<Image>()[1];
        if(img.sprite != null)
        {
            rectTransform = img.rectTransform;
            canvasGroup = img.GetComponent<CanvasGroup>();
            
        }
        //if(ItemManager.Instance.Inventory[index][0] != null)
        //Debug.Log(ItemManager.Instance.Inventory[index][0]);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UIManager.Instance.OffStoreSellPanel();
        Image img = GetComponentsInChildren<Image>()[1];
        img.maskable = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!ReferenceEquals(ItemManager.Instance.Inventory[index][0],null))
        {
            Item tmp = ItemManager.Instance.Inventory[index][0];

            Sprite sprite = tmp.itemImage;
            string str = tmp.itemName;
            int cost = tmp.price;

            UIManager.Instance.UpdateIntroducePanel(sprite, str, cost);

            int sell = int.Parse(UIManager.Instance.itemNumText[index].text) * cost;

            UIManager.Instance.UpdateAllSellText(sell);
            if(!UIManager.Instance.introducePanel.activeInHierarchy)
                UIManager.Instance.ClickOpenUI(UIManager.Instance.introducePanel);
            else
                UIManager.Instance.ClickExitBtn(UIManager.Instance.introducePanel);
        }
       
    }
}
