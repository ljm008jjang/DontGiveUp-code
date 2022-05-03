using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    private static ClickerManager _Instance;

    public static ClickerManager Instance
    {
        get
        {
            return _Instance;
        }
    }
    public int period = 1;
    public WaitForSeconds OGws;
    public WaitForSeconds ws;
    public int[] remainTime;
    /*
    WaitForSeconds ws10 = new WaitForSeconds(10f);
    WaitForSeconds ws20 = new WaitForSeconds(20f);
    WaitForSeconds ws30 = new WaitForSeconds(30f);
    WaitForSeconds ws40 = new WaitForSeconds(40f);
    WaitForSeconds ws50 = new WaitForSeconds(50f);
    WaitForSeconds ws60 = new WaitForSeconds(60f);
    WaitForSeconds ws70 = new WaitForSeconds(70f);
    WaitForSeconds ws80 = new WaitForSeconds(80f);
    WaitForSeconds ws90 = new WaitForSeconds(90f);
    WaitForSeconds ws100 = new WaitForSeconds(100f);
    WaitForSeconds ws110 = new WaitForSeconds(110f);
    WaitForSeconds ws120 = new WaitForSeconds(120f);
    WaitForSeconds ws130 = new WaitForSeconds(130f);
    WaitForSeconds ws140 = new WaitForSeconds(140f);
    */
    Player player;
    ItemManager itemManager;
    ItemDB itemDB;

    Coroutine[] mineralCoroutine;
    public List<List<Item>> clickerInventory = new List<List<Item>>();
    public ClickerManagerData clickerManagerData;

    public int maxMineralCapacity = 50;//창고 용량
    public int NumTypeOfMineral = 22;//미네랄 종류
    //
    bool isHaveMineral = false;//광물 가지고있는지 체크
    public Mineral mineral;//업그레이드 광물필요조건
    public int num;//업그레이드 개수필요조건
    //
    public int mineralNum = 0;
    public int drillLevel = 0;
    public int InventoryLevel = 1;
    public int drillCost;
    public int inventoryCost;
    [SerializeField]
    public float tmpF;
    [SerializeField]
    Image clickerAD;


    /*
    [SerializeField]
    Image clickerDrillImage;

    [SerializeField]
    Sprite[] clickerDrillsprites;
    */
    List<Mineral> mineralPrefabs;

    [SerializeField]
    Animator anim;

    private void Awake()
    {
        _Instance = this;
        tmpF = period;
    }

    private void Start()
    {
        player = Player.Instance;
        itemManager = ItemManager.Instance;
        itemDB = ItemDB.Instance;

        mineralCoroutine = new Coroutine[NumTypeOfMineral];

        remainTime = new int[itemDB.mineralPrefabs.Count];

        for (int i = 0; i < mineralCoroutine.Length; i++)
        {
            mineralCoroutine[i] = null;
        }

        GetVariable();
        
        ws = new WaitForSeconds(period);
        OGws = new WaitForSeconds(period);
        

        

        

        CalculateDrillCost();
        CalculateInventoryCost();


        
    }

    public void GetVariable()
    {
        mineralNum = clickerManagerData.mineralNum;
        drillLevel = clickerManagerData.drillLevel;
        InventoryLevel = clickerManagerData.inventoryLevel;
        maxMineralCapacity = 40 + 10 * InventoryLevel + AchievementManager.Instance.achievementManagerData.inventoryCount; ;
        for(int i=0; i < clickerManagerData.remainTime.Length; i++)
        {
            remainTime[i] = clickerManagerData.remainTime[i];
        }
        
        UIManager.Instance.clickerDrillImage.sprite = UIManager.Instance.clickerDrillsprites[drillLevel];
        if (mineralNum >= maxMineralCapacity || drillLevel.Equals(0))
        {

            anim.SetBool("IsFull", true);

            if (mineralNum >= maxMineralCapacity)
            {
                StartCoroutine(ClickerScript.Instance.ChangeColor());
            }
        }

        for(int i = 0; i < mineralCoroutine.Length; i++)
        {
            if(mineralCoroutine[i] != null)
            {
                StopCoroutine(mineralCoroutine[i]);
                mineralCoroutine[i] = null;
            }
        }

        Mining(drillLevel);
    }

    public void Initialized()
    {
        for (int i = 0; i < NumTypeOfMineral; i++)
        {
            List<Item> tmp = new List<Item>();

            clickerInventory.Add(tmp);
        }
    }

    public void Mining(int drillLevel)//인덱스는 드릴레벨을 따라가도록
    {
        if(drillLevel>0)
        for(int i = 1; i <= drillLevel; i++)
        {
                if(mineralCoroutine[i-1] == null)
                    mineralCoroutine[i-1] = StartCoroutine(DigMineral(i));// 0 ~ DrillLevel까지
        }
            
        
    }

    public void DrillUpgrade()
    {
        

        if(drillLevel < itemDB.mineralPrefabs.Count)
        {
            isHaveMineral = HaveMineral(num);

            if (GameManager.Instance.gold >= drillCost && isHaveMineral)
            {
                SoundManager.Instance.clickAudioSource.Play();
                drillLevel++;
                remainTime[drillLevel - 1] = drillLevel * 10;
                mineralCoroutine[drillLevel-1] = StartCoroutine(DigMineral(drillLevel));
                AchievementManager.Instance.achievementManagerData.useGold += drillCost;
                itemManager.SubtractItem(mineral, num);
                GameManager.Instance.gold -= drillCost;

                anim.SetBool("IsFull", false);

                UIManager.Instance.clickerDrillImage.sprite = UIManager.Instance.clickerDrillsprites[drillLevel];

                UIManager.Instance.UpdateClickerInventoryUI();
                UIManager.Instance.UpdateGoldText();


                
            }
            else
            {
                SoundManager.Instance.clickFailAudioSource.Play();
            }

            CalculateDrillCost();
            UIManager.Instance.UpdateClickerDrillUpgradeText();
        }
        else
        {
            SoundManager.Instance.clickFailAudioSource.Play();
            UIManager.Instance.clickerDrillUpgradeImage.sprite = null;
            UIManager.Instance.clickerDrillUpgradeText.text = "All Upgrade";
        }

        OnOffDrillUI();
    }

    public void OnOffDrillUI()
    {
        if (drillLevel >= itemDB.mineralPrefabs.Count)
        {
            UIManager.Instance.clickerDrillUpgradeText.gameObject.SetActive(false);
            UIManager.Instance.clickerdrillMineralText.gameObject.SetActive(false);
            UIManager.Instance.clickerDrillUpgradeImage.gameObject.SetActive(false);
            UIManager.Instance.ClickerdrillLevelText.gameObject.SetActive(false);
            UIManager.Instance.clickerDrillSubText.gameObject.SetActive(false);
            UIManager.Instance.clickerDrillMoneyImage.gameObject.SetActive(false);

            UIManager.Instance.clickerDrillMaxLevelText.gameObject.SetActive(true);
        }
    }

    public void CalculateDrillCost()
    {
        switch (drillLevel)//현재 레벨
        {
            case 0:
                drillCost = 10000;
                mineral = itemDB.coalPrefab;
                num = 10;
                break;
            case 1:
                drillCost = 30000;
                mineral = itemDB.bronzePrefab;
                num = 15;
                break;
            case 2:
                drillCost = 50000;
                mineral = itemDB.silverPrefab;
                num = 20;
                break;
            case 3:
                drillCost = 100000;
                mineral = itemDB.goldPrefab;
                num = 25;
                break;
            case 4:
                drillCost = 200000;
                mineral = itemDB.crystalPrefab;
                num = 30;
                break;
            case 5:
                drillCost = 300000;
                mineral = itemDB.rubyPrefab;
                num = 35;
                break;
            case 6:
                drillCost = 400000;
                mineral = itemDB.platinumPrefab;
                num = 40;
                break;
            case 7:
                drillCost = 500000;
                mineral = itemDB.diamondPrefab;
                num = 40;
                break;
            case 8:
                drillCost = 600000;
                mineral = itemDB.sapphirePrefab;
                num = 40;
                break;
            case 9:
                drillCost = 700000;
                mineral = itemDB.emeraldPrefab;
                num = 40;
                break;
            case 10:
                drillCost = 800000;
                mineral = itemDB.pinkdiamondPrefab;
                num = 40;
                break;
            case 11:
                drillCost = 900000;
                mineral = itemDB.amethystPrefab;
                num = 40;
                break;
            case 12:
                drillCost = 1000000;
                mineral = itemDB.morionPrefab;
                num = 40;
                break;
            case 13:
                drillCost = 1200000;
                mineral = itemDB.opalPrefab;
                num = 40;
                break;
            case 14:
                drillCost = 1400000;
                mineral = itemDB.blackdiamondPrefab;
                num = 40;
                break;
            case 15:
                drillCost = 1600000;
                mineral = itemDB.radiumPrefab;
                num = 40;
                break;
            case 16:
                drillCost = 1800000;
                mineral = itemDB.scandiumPrefab;
                num = 40;
                break;
            case 17:
                drillCost = 2000000;
                mineral = itemDB.uraniumPrefab;
                num = 40;
                break;
            case 18:
                drillCost = 2200000;
                mineral = itemDB.plutoniumPrefab;
                num = 40;
                break;
            case 19:
                drillCost = 2400000;
                mineral = itemDB.californiumPrefab;
                num = 40;
                break;
            case 20:
                drillCost = 2600000;
                mineral = itemDB.poloniumPrefab;
                num = 40;
                break;
            case 21:
                drillCost = 2800000;
                mineral = itemDB.franciumPrefab;
                num = 40;

                break;
        }
    }

    public void InventoryUpgrade()
    {
        

        if (GameManager.Instance.gold >= inventoryCost)
        {
            SoundManager.Instance.clickAudioSource.Play();
            maxMineralCapacity += 10;
            InventoryLevel++;
            AchievementManager.Instance.achievementManagerData.useGold += inventoryCost;
            GameManager.Instance.gold -= inventoryCost;
            UIManager.Instance.UpdateGoldText();

            CalculateInventoryCost();
        }
        else
        {
            SoundManager.Instance.clickFailAudioSource.Play();
        }

        
        UIManager.Instance.UpdateClickerInventoryUpgradeText();
        UIManager.Instance.UpdateClickerInventoryCapacityText();
    }

    public void CalculateInventoryCost()
    {
        switch (InventoryLevel)//현재 레벨
        {
            case 1:
                inventoryCost = 10000;
                break;
            case 2:
                inventoryCost = 30000;
                break;
            case 3:
                inventoryCost = 50000;
                break;
            case 4:
                inventoryCost = 70000;
                break;
            case 5:
                inventoryCost = 100000;
                break;
            case 6:
                inventoryCost = 200000;
                break;
            case 7:
                inventoryCost = 400000;
                break;
            case 8:
                inventoryCost = 600000;
                break;
            case 9:
                inventoryCost = 800000;
                break;
            case 10:
                inventoryCost = 1000000;
                break;
            case 11:
                inventoryCost = 1400000;
                break;
            case 12:
                inventoryCost = 1800000;
                break;
            case 13:
                inventoryCost = 2200000;
                break;
            case 14:
                inventoryCost = 3000000;
                break;
            case 15:
                inventoryCost = 4000000;
                break;
            default:
                inventoryCost += 1000000;
                break;
                /*
            case 16:
                inventoryCost = 5000000;
                break;
            case 17:
                inventoryCost = 6000000;
                break;
            case 18:
                inventoryCost = 7000000;
                break;
            case 19:
                inventoryCost = 8000000;
                break;
                */
        }
    }

    public bool HaveMineral(int num)
    {
        for(int i = 0; i < itemManager.Inventory.Count; i++)
        {
            if (!ReferenceEquals( itemManager.Inventory[i][0],null) && itemManager.Inventory[i][0].itemName.Equals(mineral.itemName))//원하는 광물이면
            {
                if(!ReferenceEquals(itemManager.Inventory[i][num - 1], null))
                {
                    return true;
                }
                break;
            }
        }
        return false;
    }

    IEnumerator DigMineral(int index)//광물마다 제한 X, 전체적 용량 제한이 존재하므로 다른 로직을 작성해야됨
    {
        //for (int i = 1; i < itemDB.mineralPrefabs.Count; i++)
        {
            if (index>0)
            {
                while (true)
                {
                    
                    while(remainTime[index-1]-AchievementManager.Instance.achievementManagerData.clickerMinusTime > 0)
                    {
                        
                        if (mineralNum < maxMineralCapacity)
                        {
                            remainTime[index - 1]--;
                            if(UIManager.Instance.clickerPanel.activeInHierarchy)
                                UIManager.Instance.UpdateMineralTime(index-1);
                        }
                        yield return ws;

                    }

                    while (true)
                    {
                        if (mineralNum < maxMineralCapacity)
                        {
                            clickerInventory[index - 1].Add(itemDB.mineralPrefabs[index - 1]);

                            mineralNum++;

                            QuestManager.Instance.questManagerData.mineral[index - 1]++;

                            remainTime[index - 1] = index * 10;

                            if (mineralNum >= maxMineralCapacity)
                            {
                                anim.SetBool("IsFull", true);
                                StartCoroutine(ClickerScript.Instance.ChangeColor());
                            }

                            if (UIManager.Instance.clickerPanel.activeInHierarchy)
                            {
                                UIManager.Instance.UpdateClickerTextUI(index - 1);
                                UIManager.Instance.UpdateClickerInventoryCapacityText();
                            }
                            break;
                        }
                        else
                        {
                            yield return ws;
                        }
                    }
                    

                    

                }
            }
        }
    }

    public void Print()
    {

        for (int i = 0; i < clickerInventory.Count; i++)
            for (int j = 0; j < clickerInventory[i].Count; j++)
            {
                if (!ReferenceEquals(clickerInventory[i][j], null))
                {
                    Debug.Log(i + ", " + j + " " + clickerInventory[i][j].itemName);
                }
            }

    }

    public void GetMineral(int index)
    {
        SoundManager.Instance.clickAudioSource.Play();

        int count = clickerInventory[index].Count;
        for (int i = 0; i < count; i++)
        {
            itemManager.AddItem(clickerInventory[index][0]);
            clickerInventory[index].RemoveAt(0);
        }

        mineralNum -= count;

        if(drillLevel != 0)
        anim.SetBool("IsFull", false);
        

        UIManager.Instance.UpdateClickerTextUI(index);
        UIManager.Instance.UpdateClickerInventoryUI();
        UIManager.Instance.UpdateClickerInventoryCapacityText();
    }

    public void ClickerAdamant()
    {
        if (true)
        {
            if (GameManager.Instance.adamant >= 200)
            {
                GameManager.Instance.adamant -= 200;
                UIManager.Instance.UpdateAdamantText();
                StartCoroutine(ClickerAD());
            }
        }
    }



    public IEnumerator ClickerAD()//작동중 저장하고 끄면 어케되지?
    {
        float clickerCoeffient;
        //WaitForSeconds tmpWs = ClickerManager.Instance.ws;
        clickerCoeffient = 0.33f;
        tmpF *= clickerCoeffient;
        /*
        if (tmpF < 0.1f)
        {
            tmpF = 0.1f;
        }
        */
        ws = new WaitForSeconds(tmpF);
        clickerAD.fillAmount = 0;
        clickerAD.transform.GetComponent<Button>().enabled = false;
        for (int i = 0; i < 600; i++)
        {
            yield return OGws;
            clickerAD.fillAmount += 0.00166f;
        }
        clickerAD.transform.GetComponent<Button>().enabled = true;

        tmpF /= clickerCoeffient;

        ws = new WaitForSeconds(tmpF);
    }



}




[System.Serializable]
public class ClickerManagerData
{
    public List<int> clickerInventory = new List<int>();
    public int mineralNum;
    public int drillLevel;
    public int inventoryLevel;
    public int[] remainTime;
}
