using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _Instance;

    public static UIManager Instance
    {
        get
        {
            return _Instance;
        }
    }
    [SerializeField]
    Player player;
    [SerializeField]
    ItemManager itemManager;
    [SerializeField]
    Image[] parentImgs;
    
    public TextMeshProUGUI[] itemNumText;
    [SerializeField]
    Image[] clickerParentImgs;
    [SerializeField]
    TextMeshProUGUI[] clickerItemNumText;
    WaitForSeconds oneSec = new WaitForSeconds(1);

    public GameObject DeadUI;
    public Button reviveBtn;
    public Slider oxygenSlider;
    public Slider fuelSlider;
    public Slider HealthSlider;    
    public Slider clickerPowerUpSlider;
    public Slider drillPowerUpSlider;
    [SerializeField]
    Slider moneyBoxSlider;
    [SerializeField]
    Slider adamantBoxSlider;
    [SerializeField]
    Slider backgroundAudioSlider;
    public
    Slider playerUIAlphaSlider;
    public GameObject storePanel;
    public GameObject clickerPanel;
    public GameObject inventoryUI;
    public GameObject clickerInventoryUI;
    public GameObject cashStorePanel;
    public GameObject settingPage;
    public GameObject saveMsg;
    public GameObject storeBackground;
    public GameObject storeTemporaryText;
    public
    Image saveCompleteObj;
    public
    TextMeshProUGUI saveCompleteText;
    [SerializeField]
    GameObject cloudPanel;
    [SerializeField]
    GameObject storeTemporaryBuyBtn;
    [SerializeField]
    GameObject miniMapUI;
    [SerializeField]
    GameObject rewardPage;
    [SerializeField]
    GameObject[] cashStoreIntroduces;
    [SerializeField]
    GameObject miniMapCamera;
    [SerializeField]
    GameObject GNSceneUI;
    [SerializeField]
    GameObject GPSceneUI;
    public
    GameObject Store;
    [SerializeField]
    GameObject noKeyPanel;
    [SerializeField]
    GameObject moneyBoxPanel;
    [SerializeField]
    GameObject adamantBoxPanel;
    [SerializeField]
    GameObject rainbowPanel;
    [SerializeField]
    GameObject updatePanel;
    [SerializeField]
    GameObject keyPanel;
    [SerializeField]
    GameObject storeSellPanel;
    [SerializeField]
    GameObject coolTimePanel;
    public GameObject introducePanel;
    public
    GameObject storeTicketBtn; 

    public GameObject tutorialPanel;
    public GameObject tutorialFirstPanel;
    public GameObject talkBox;

    public Image clickerPowerUpUI;
    public Image drillPowerUpUI;
    public Image clickerDrillUpgradeImage;
    
    public Image clickerDrillImage;
    public Image saveMsgBackground;
    public Sprite[] clickerDrillsprites;
    public Image clickerDrillMoneyImage;
    public Image debuffImage;
    [SerializeField]
    Image storeDrillImage;
    [SerializeField]
    Image storeCapImage;
    [SerializeField]
    Image introduceImage;
    [SerializeField]
    TextMeshProUGUI introduceNameText;
    [SerializeField]
    TextMeshProUGUI introducePriceText;
    [SerializeField]
    TextMeshProUGUI cloudSaveText;
    [SerializeField]
    Sprite[] storeDrillImages;
    [SerializeField]
    Sprite[] storeCapImages;
    
    public Sprite[] backgroundImages;
    [SerializeField]
    Image monsterRewardImage;
    [SerializeField]
    Image currentDrillImage;
    [SerializeField]
    Image currentCapImage;
    [SerializeField]
    Image[] cashStoreAfterUpgradeImages;

    public Image rainbowRewardImage;

    [SerializeField]
    Sprite money;
    [SerializeField]
    Sprite adamant;
    public SpriteRenderer backgroundImage;
    [SerializeField]
    Toggle monitorToggle;
    [SerializeField]
    Toggle monitorToggleTmp;
    [SerializeField]
    Toggle backgroundSoundToggle;
    [SerializeField]
    Toggle effectSoundToggle;
    [SerializeField]
    Toggle miniMapToggle;
    [SerializeField]
    Toggle[] moveButtonToggle;


    public TextMeshProUGUI[] usableItemText;
    public TextMeshProUGUI[] clickerInventoryText;
    public TextMeshProUGUI[] storeEquipmentCostText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI adamantText;
    public TextMeshProUGUI heightText;
    public TextMeshProUGUI InventoryFullText;
    public TextMeshProUGUI clickerDrillUpgradeText;
    public TextMeshProUGUI clickerdrillMineralText;
    public TextMeshProUGUI clickerInventoryUpgradeCostText;
    public TextMeshProUGUI clickerInventoryUpgradeIntroduceText;
    public TextMeshProUGUI clickerInventoryCapacityText;
    public TextMeshProUGUI drillLevelText;
    public TextMeshProUGUI CapLevelText;
    public TextMeshProUGUI ClickerdrillLevelText;
    public TextMeshProUGUI ClickerInventoryLevelText;
    //public TextMeshProUGUI playerGoldText;
    public TextMeshProUGUI[] mineralTime;
    public TextMeshProUGUI[] cashStoreCostText;
    public TextMeshProUGUI MonsterRewardText;
    public PortalR portalR;
    public PortalL portalL;
    public TextMeshProUGUI[] storeSubText;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI moneyRewardText;
    public TextMeshProUGUI adamantRewardText;
    public TextMeshProUGUI moneyWaitText;
    public TextMeshProUGUI rainbowRewardText;
    public TextMeshProUGUI clickerDrillSubText;
    public TextMeshProUGUI saveMsgText;
    [SerializeField]
    TextMeshProUGUI currentDrillLevelText;
    [SerializeField]
    TextMeshProUGUI currentCapLevelText;
    [SerializeField]
    TextMeshProUGUI currentDrillPowerText;
    [SerializeField]
    TextMeshProUGUI currentCapPowerText;
    [SerializeField]
    TextMeshProUGUI drillMaxLevelText;
    [SerializeField]
    TextMeshProUGUI capMaxLevelText;
    public
    TextMeshProUGUI clickerDrillMaxLevelText;
    public
    TextMeshProUGUI clickerInventoryMaxLevelText;
    [SerializeField]
    TextMeshProUGUI allSellText;

    public Coroutine talkBoxCoroutine = null;

    public TextMeshProUGUI playerText;

    public GameObject[] cashStoreBuyBtn;

    public GameObject exitUI;
    public GameObject gameExitUI;
    public GameObject pausePanel;
    private GameObject opendUI;
    public ParticleSystem blockHit;

    public Image[] playerUI;
    public RawImage minimapImage;

    public GameObject[] moveButton;
    bool drillBuff = false;//광고변수들
    bool dynamiteBuff = false;
    public bool oxygenBuff = false;
    public bool boosterBuff = false;
    [SerializeField]
    Image[] ADBtns;
    private void Awake()
    {
        _Instance = this;
        //parentImgs = inventoryUI.GetComponentsInChildren<Image>();
        //itemNumText = inventoryUI.GetComponentsInChildren<TextMeshProUGUI>();
        //clickerParentImgs = clickerInventoryUI.GetComponentsInChildren<Image>();
        //clickerItemNumText = clickerInventoryUI.GetComponentsInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        itemManager = ItemManager.Instance;

        UpdateStageText();
        UpdateGoldText();
        //UpdateGoldText();
        UpdateAdamantText();
        fuelSlider.maxValue = player.maxFuel;
        HealthSlider.maxValue = player.maxHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameExitUI.gameObject.SetActive(true);
        }
    }
    /*
    public void UpdateGoldText()
    {
        playerGoldText.text = GameManager.Instance.gold.ToString();
    }
    */
    public IEnumerator OxygenUIUpdate()
    {
        while (player.isAlive)
        {
            oxygenSlider.value = Mathf.Lerp(oxygenSlider.value,player.OxygenRemain,Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator FuelUIUpdate()
    {
        while (player.isAlive)
        {
            fuelSlider.value = Mathf.Lerp(fuelSlider.value,player.fuelRemain,Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator HeightUIUpdate()
    {
        while (player.isAlive)
        {
            heightText.text = (int)player.transform.position.y + "m";
            yield return null;
        }
    }

    public void HealthUIUpdate()
    {
        HealthSlider.value = player.health;
        
    }

    public void ClickOpenStoreBtn()
    {
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = true;
        UpdateStoreInventoryUI();
        UpdateGoldText();
        storePanel.gameObject.SetActive(true);
        //Store.gameObject.SetActive(true);
        exitUI.gameObject.SetActive(true);
        opendUI = storePanel;
        UpdateEquipmentCostUI();
        UpdateCurrentCap();
        UpdateCurrentDrill();
        UpdateStoreDrillAndCapUpgradeSub();
        storeBackground.gameObject.SetActive(false);
        //storeTicketBtn.gameObject.SetActive(false);
        
    }

    public void UpdateEquipmentCostUI()
    {
        
        if(player.drillLevel < player.maxDrillLevel)
        {
            StoreManager.Instance.CalculateDrillCost();
            storeEquipmentCostText[0].text = string.Format("{0:N0}",StoreManager.Instance.drillCost );
            drillLevelText.text = "Level: " + (player.drillLevel + 1).ToString();
            
            if (player.drillLevel.Equals(1))
            {
                storeDrillImage.sprite = storeDrillImages[1];
            }
            else
                storeDrillImage.sprite = storeDrillImages[(player.drillLevel - 1) * 5 + 1];

        }
        else
        {
            storeSubText[0].gameObject.SetActive(false);
            storeEquipmentCostText[0].gameObject.SetActive(false);
            drillLevelText.gameObject.SetActive(false);
            storeDrillImage.gameObject.SetActive(false);
            drillMaxLevelText.gameObject.SetActive(true);
        }
        if(player.capLevel < player.maxCapLevel)
        {
            StoreManager.Instance.CalculateCapCost();
            storeEquipmentCostText[1].text = string.Format("{0:N0}",StoreManager.Instance.capCost);
            CapLevelText.text = "Level: " + (player.capLevel + 1).ToString();

            storeCapImage.sprite = storeCapImages[player.capLevel * 4];
        }
        else
        {
            storeSubText[1].gameObject.SetActive(false);
            storeEquipmentCostText[1].gameObject.SetActive(false);
            CapLevelText.gameObject.SetActive(false);
            storeCapImage.gameObject.SetActive(false);
            capMaxLevelText.gameObject.SetActive(true);
        }
        
    }

    public void UpdateCashStoreCostUI(int index)
    {
        switch (index)
        {
            case 0:
                if (CashStoreManager.Instance.drillLevel <= 11)
                {
                    CashStoreManager.Instance.CalculateDrillPowerUpCost();
                    cashStoreCostText[0].text = string.Format("{0:N0}",CashStoreManager.Instance.drillCost) ;
                    cashStoreCostText[2].text = "효과 : 사용시 드릴파워 " + (1 + ((CashStoreManager.Instance.drillLevel + 1) * 0.1f)) + "배 증폭\n\n지속시간 : 1분\n쿨타임 : 5분";
                    cashStoreCostText[3].text = "Level: " + (CashStoreManager.Instance.drillLevel + 1);
                }
                else
                {
                    CashStoreManager.Instance.CalculateDrillPowerUpCost();
                    cashStoreCostText[0].text = string.Format("{0:N0}",CashStoreManager.Instance.drillCost );
                    cashStoreCostText[2].text = "효과 : 사용시 드릴파워 " + (1 + (CashStoreManager.Instance.drillLevel * 0.1f)) + "배 증폭\n\n지속시간 : 1분\n쿨타임 : 5분";
                    cashStoreCostText[3].text = "Level: " + (CashStoreManager.Instance.drillLevel);
                }

                break;
            case 1:
                    CashStoreManager.Instance.CalculateDrillPowerUpCost();
                    cashStoreCostText[5].text = string.Format("{0:N0}", CashStoreManager.Instance.drillCost);
                    cashStoreCostText[7].text = "효과 : 사용시 드릴파워 " + (1 + ((CashStoreManager.Instance.drillLevel) * 0.1f)) + "배 증폭\n\n지속시간 : 1분\n쿨타임 : 5분";
                    cashStoreCostText[6].text = "Level: " + (CashStoreManager.Instance.drillLevel);
                    cashStoreCostText[9].text = "효과 : 사용시 드릴파워 " + (1 + ((CashStoreManager.Instance.drillLevel + 1) * 0.1f)) + "배 증폭\n\n지속시간 : 1분\n쿨타임 : 5분";
                    cashStoreCostText[8].text = "Level: " + (CashStoreManager.Instance.drillLevel + 1);
                break;
            case 2://아직안끝남
                if (CashStoreManager.Instance.clickerLevel <= 11)
                {
                    CashStoreManager.Instance.CalculateClickerPowerUpCost();
                    cashStoreCostText[10].text = string.Format("{0:N0}", CashStoreManager.Instance.clickerCost);
                    cashStoreCostText[12].text = "효과 : 사용시 채굴 효울 " + ((CashStoreManager.Instance.clickerLevel + 1) * 0.05f*100) + "% 증가\n\n지속시간 : 30초\n쿨타임 : 3분";
                    cashStoreCostText[13].text = "Level: " + (CashStoreManager.Instance.clickerLevel + 1);
                }
                else
                {
                    CashStoreManager.Instance.CalculateClickerPowerUpCost();
                    cashStoreCostText[10].text = string.Format("{0:N0}", CashStoreManager.Instance.clickerCost);
                    cashStoreCostText[12].text = "효과 : 사용시 채굴 효울 " + (CashStoreManager.Instance.clickerLevel * 0.05f*100) + "% 증가\n\n지속시간 : 30초\n쿨타임 : 3분";
                    cashStoreCostText[13].text = "Level: " + (CashStoreManager.Instance.clickerLevel);
                }
                break;
            case 3://아직안끝남
                    CashStoreManager.Instance.CalculateClickerPowerUpCost();
                    cashStoreCostText[15].text = string.Format("{0:N0}", CashStoreManager.Instance.clickerCost);
                cashStoreCostText[17].text = "효과 : 사용시 채굴 효울 " + ((CashStoreManager.Instance.clickerLevel) * 0.05f*100) + "% 증가\n\n지속시간 : 30초\n쿨타임 : 3분";
                cashStoreCostText[16].text = "Level: " + (CashStoreManager.Instance.clickerLevel);
                    cashStoreCostText[19].text = "효과 : 사용시 채굴 효울 " + ((CashStoreManager.Instance.clickerLevel + 1) * 0.05f*100) + "% 증가\n\n지속시간 : 30초\n쿨타임 : 3분";
                cashStoreCostText[18].text = "Level: " + (CashStoreManager.Instance.clickerLevel + 1);
                    break;
            case 4:
                CashStoreManager.Instance.CalculateBoosterCost();
                cashStoreCostText[20].text = string.Format("{0:N0}",CashStoreManager.Instance.boosterCost.ToString());
                cashStoreCostText[22].text = "부스터 증가 : " + (((CashStoreManager.Instance.boosterLevel) * 0.5f) + ((CashStoreManager.Instance.boosterLevel - 8) * 0.5f) + ((CashStoreManager.Instance.boosterLevel - 11) * 0.5f)) * 100;
                cashStoreCostText[23].text = "Level: " + (CashStoreManager.Instance.boosterLevel);
                break;
            case 5:
                if (CashStoreManager.Instance.boosterLevel <= 15)
                {
                    CashStoreManager.Instance.CalculateBoosterCost();
                    cashStoreCostText[25].text = string.Format("{0:N0}",CashStoreManager.Instance.boosterCost.ToString() );
                    if (CashStoreManager.Instance.boosterLevel < 8)
                    {
                        cashStoreCostText[27].text = "부스터 증가 : " + (CashStoreManager.Instance.boosterLevel * 0.5f)*100;
                        cashStoreCostText[29].text = "부스터 증가 : " + ((CashStoreManager.Instance.boosterLevel + 1) * 0.5f) * 100;
                    }
                    else if (CashStoreManager.Instance.boosterLevel < 11)
                    {
                        cashStoreCostText[27].text = "부스터 증가 : " + (((CashStoreManager.Instance.boosterLevel) * 0.5f) + ((CashStoreManager.Instance.boosterLevel - 8) * 0.5f)) * 100;
                        cashStoreCostText[29].text = "부스터 증가 : " + (((CashStoreManager.Instance.boosterLevel + 1) * 0.5f) + ((CashStoreManager.Instance.boosterLevel + 1 - 8) * 0.5f)) * 100;
                    }
                    else
                    {
                        cashStoreCostText[27].text = "부스터 증가 : " + (((CashStoreManager.Instance.boosterLevel) * 0.5f) + ((CashStoreManager.Instance.boosterLevel - 8) * 0.5f) + ((CashStoreManager.Instance.boosterLevel - 11) * 0.5f)) * 100;
                        cashStoreCostText[29].text = "부스터 증가 : " + (((CashStoreManager.Instance.boosterLevel + 1) * 0.5f) + ((CashStoreManager.Instance.boosterLevel + 1 - 8) * 0.5f) + ((CashStoreManager.Instance.boosterLevel + 1 - 11) * 0.5f)) * 100;
                    }
                    cashStoreCostText[26].text = "Level: " + (CashStoreManager.Instance.boosterLevel);
                    cashStoreCostText[28].text = "Level: " + (CashStoreManager.Instance.boosterLevel + 1);
                }
                else
                {
                    cashStoreCostText[25].text = "최고 레벨!";
                    cashStoreCostText[26].text = "Level: " + (CashStoreManager.Instance.boosterLevel);
                    cashStoreCostText[27].text = "부스터 증가 : " + (((CashStoreManager.Instance.boosterLevel) * 0.5f) + ((CashStoreManager.Instance.boosterLevel - 8) * 0.5f) + ((CashStoreManager.Instance.boosterLevel - 11) * 0.5f)) * 100;
                    cashStoreCostText[28].gameObject.SetActive(false);
                    cashStoreCostText[29].gameObject.SetActive(false);
                    cashStoreAfterUpgradeImages[4].gameObject.SetActive(false);
                    cashStoreAfterUpgradeImages[5].gameObject.SetActive(false);
                }
                
                break;
            case 6:
                if(itemManager.isBuyPermanentStoreTicket)
                storeTemporaryBuyBtn.gameObject.SetActive(false);
                break;
        }
    }

    public void ClickExitStoreBtn()
    {
        SoundManager.Instance.clickAudioSource.Play();

        introducePanel.gameObject.SetActive(false);

        storePanel.gameObject.SetActive(false);

        




        GameManager.Instance.isGameStop = false;
    }

    public void DrillPowerUp()
    {
        player.miningPower += 0.1f;
    }

    public void HealthUp()
    {
        player.maxHealth++;
    }

    public void UpdateStoreInventoryUI()//플레이어 인벤토리
    {
       //Image[] parentImgs = inventoryUI.GetComponentsInChildren<Image>();

        for (int i = 0; i < ItemManager.Instance.Inventory.Count; i++)
        {
            //Debug.Log(ItemManager.Instance.Inventory.Count);
            //Debug.Log(ItemManager.Instance.Inventory[4][1]);
            if (ItemManager.Instance.Inventory[i][0] != null)
            {
                
                parentImgs[i].sprite = ItemManager.Instance.Inventory[i][0].itemImage;

                int x = 0;
                for(int j = 0; j < ItemManager.Instance.limitSet; j++)
                {
                    if (ItemManager.Instance.Inventory[i][j] != null)
                    {
                        x++;
                    }
                    else
                        break;
                }
                itemNumText[i].text = x.ToString();
            }
            else
            {
                //Debug.Log(i);
                //Debug.Log("안됨");
                parentImgs[i].sprite = null;
                itemNumText[i].text = "";
            }
        }
    }

    public void UpdateUsableItemUI()//각각의 아이템이 쓰거나 얻어지면 해당 ui만 변하도록 할까?
    {
        usableItemText[0].text = itemManager.bomb.ToString();
        usableItemText[1].text = itemManager.dynamite.ToString();
        usableItemText[2].text = itemManager.oxygenCapsule.ToString();
        usableItemText[3].text = itemManager.aidPack.ToString();
        usableItemText[4].text = itemManager.teleport.ToString();
    }

    public void UpdateBombUI()
    {
        usableItemText[0].text = itemManager.bomb.ToString();
    }
    public void UpdateDynamiteUI()
    {
        usableItemText[1].text = itemManager.dynamite.ToString();
    }
    public void UpdateOxygenCapsuleUI()
    {
        usableItemText[2].text = itemManager.oxygenCapsule.ToString();
    }
    public void UpdateAidPackUI()
    {
        usableItemText[3].text = itemManager.aidPack.ToString();
    }
    public void UpdateTeleportUI()
    {
        usableItemText[4].text = itemManager.teleport.ToString();
    }

    public void UpdateGoldText()
    {
        goldText.text = string.Format("{0:N0}", GameManager.Instance.gold);
        
    }

    public void ClickOpenClickerUI()
    {
        SoundManager.Instance.clickAudioSource.Play();

        UpdateClickerInventoryUI();
        UpdateAllClickerTextUI();
        UpdateClickerDrillUpgradeText();
        UpdateClickerInventoryUpgradeText();
        UpdateClickerInventoryCapacityText();
        for(int i=0;i<ClickerManager.Instance.NumTypeOfMineral;i++)
            UpdateMineralTime(i);
        GameManager.Instance.isGameStop = true;
        clickerPanel.SetActive(true);
        exitUI.gameObject.SetActive(true);
        opendUI = clickerPanel;
    }

    public void ClickExitClickerBtn()
    {
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = false;
        clickerPanel.SetActive(false);
    }

    public void UpdateClickerInventoryUI()//플레이어 인벤토리 in Clicker
    {
        //Image[] parentImgs = inventoryUI.GetComponentsInChildren<Image>();

        for (int i = 0; i < ItemManager.Instance.Inventory.Count; i++)
        {

            if (ItemManager.Instance.Inventory[i][0] != null)
            {
                clickerParentImgs[i].sprite = ItemManager.Instance.Inventory[i][0].itemImage;

                int x = 0;
                for (int j = 0; j < ItemManager.Instance.limitSet; j++)
                {
                    if (ItemManager.Instance.Inventory[i][j] != null)
                    {
                        x++;
                    }
                    else
                        break;
                }
                clickerItemNumText[i].text = x.ToString();
            }
            else
            {
                clickerParentImgs[i].sprite = null;
                clickerItemNumText[i].text = "";
            }
        }
    }

    public void UpdateAllClickerTextUI()
    {
        for(int i = 0; i < clickerInventoryText.Length; i++)
        {
            clickerInventoryText[i].text = ClickerManager.Instance.clickerInventory[i].Count.ToString();
        }
    }

    public void UpdateClickerTextUI(int index)
    {

        clickerInventoryText[index].text = ClickerManager.Instance.clickerInventory[index].Count.ToString();

            
    }
    public void OnFullText()
    {
        InventoryFullText.gameObject.SetActive(true);
        Invoke("OffFullText", 1f);
    }

    public void OffFullText()
    {
        InventoryFullText.gameObject.SetActive(false);
    }

    public void ClickOpenCashStoreUI()
    {
        SoundManager.Instance.clickAudioSource.Play();

        GameManager.Instance.isGameStop = true;
        cashStorePanel.gameObject.SetActive(true);
        exitUI.gameObject.SetActive(true);
        opendUI = cashStorePanel;
        UpdateAdamantText();
    }

    public void UpdateAdamantText()
    {
        adamantText.text = string.Format("{0:N0}", GameManager.Instance.adamant);
        
    }

    public void ClickExitCashStoreUI()
    {
        SoundManager.Instance.clickAudioSource.Play();

        GameManager.Instance.isGameStop = false;
        cashStorePanel.gameObject.SetActive(false);
    }

    public IEnumerator ClickerPowerUpUIUpdate()
    {
        while (ClickerPowerScript.Instance.gauge < ClickerPowerScript.Instance.maxGauge)
        {
            clickerPowerUpSlider.value = ClickerPowerScript.Instance.gauge;
            yield return oneSec;
        }
    }

    public void UpdateClickerDrillUpgradeText()
    {
        if(ClickerManager.Instance.drillLevel < ItemDB.Instance.mineralPrefabs.Count)
        {
            clickerDrillUpgradeText.text = string.Format("{0:N0}", ClickerManager.Instance.drillCost);
            clickerdrillMineralText.text = ClickerManager.Instance.num.ToString();
            clickerDrillUpgradeImage.sprite = ClickerManager.Instance.mineral.itemImage;
            ClickerdrillLevelText.text = "Level: " + ClickerManager.Instance.drillLevel.ToString();
        }
        else
        {
            ClickerManager.Instance.OnOffDrillUI();
        }
        
    }

    public void UpdateClickerInventoryUpgradeText()
    {
        clickerInventoryUpgradeCostText.text = string.Format("{0:N0}", ClickerManager.Instance.inventoryCost);
        ClickerInventoryLevelText.text = "Level: " + ClickerManager.Instance.InventoryLevel.ToString();
        clickerInventoryUpgradeIntroduceText.text = "(최대 저장량 " + ClickerManager.Instance.maxMineralCapacity +
            "->" + (ClickerManager.Instance.maxMineralCapacity + 10) + ")";
    }

    public void UpdateClickerInventoryCapacityText()
    {
        clickerInventoryCapacityText.text = "최대 저장량: " + ClickerManager.Instance.maxMineralCapacity +
            "\n현재 저장량: " + ClickerManager.Instance.mineralNum;
    }

    public IEnumerator DrillPowerUpUIUpdate()//버프
    {
        while (DrillPowerScript.Instance.gauge < DrillPowerScript.Instance.maxGauge)
        {
            drillPowerUpSlider.value = DrillPowerScript.Instance.gauge;
            yield return oneSec;
        }
    }

    public IEnumerator MoneyBoxSliderUpdate()//버프
    {
        while (MoneyBox.Instance.count < moneyBoxSlider.maxValue)
        {
            moneyBoxSlider.value = MoneyBox.Instance.count;
            yield return oneSec;
        }
    }

    public IEnumerator AdamantBoxSliderUpdate()//버프
    {
        while (AdamantBox.Instance.count < adamantBoxSlider.maxValue)
        {
            adamantBoxSlider.value = AdamantBox.Instance.count;
            yield return oneSec;
        }
    }

    public void OpenSettingUI()
    {
        SoundManager.Instance.clickAudioSource.Play();

        if (!settingPage.gameObject.activeInHierarchy)
        {
            GameManager.Instance.isGameStop = true;
            settingPage.gameObject.SetActive(true);
        }
            
        else if (settingPage.gameObject.activeInHierarchy)
        {
            GameManager.Instance.isGameStop = false;
            settingPage.gameObject.SetActive(false);
        }
            
    }

    public void ChangeMonitor()
    {

        if (!monitorToggle.isOn)
        {

            Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 800;
            Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 450;

        }
        else
        {
            Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 480;
            Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 270;

        }

        SettingManager.Instance.isMontiorChecked = monitorToggle.isOn;

    }


    /*
    public void backgroundSoundOnOff()
    {
        if (!backgroundSoundToggle.isOn)
        {
            SoundManager.Instance.backgroundAudioSource.Stop();
        }
        else
        {
            SoundManager.Instance.backgroundAudioSource.Play();
        }

        SettingManager.Instance.isBGSChecked = backgroundSoundToggle.isOn;
    }
    */
    public void effectSoundOnOff()
    {
        if (effectSoundToggle.isOn)
        {
            for (int i = 0; i < SoundManager.Instance.soundEffect.Length; i++)
                SoundManager.Instance.soundEffect[i].volume = 1;
        }
        else
        {
            for (int i = 0; i < SoundManager.Instance.soundEffect.Length; i++)
                SoundManager.Instance.soundEffect[i].volume = 0;
        }

        SettingManager.Instance.isESChecked = effectSoundToggle.isOn;
    }

    public void MiniMapOnOff()
    {
        if (miniMapToggle.isOn)
        {
            miniMapCamera.gameObject.SetActive(true);
            miniMapUI.gameObject.SetActive(true);
        }
        else
        {

            miniMapUI.gameObject.SetActive(false);
                miniMapCamera.gameObject.SetActive(false);
        }

        SettingManager.Instance.isMMChecked = miniMapToggle.isOn;
    }

    public void ChangeMonitorTmp()
    {

        if (!SettingManager.Instance.isMontiorChecked)
        {

            Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 1000;
            Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 500;

        }
        else
        {
            Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 500;
            Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 250;

        }
    }

    public void UpdateSettingData()
    {
        settingPage.gameObject.SetActive(true);
        //monitorToggle.isOn = SettingManager.Instance.isMontiorChecked;
        effectSoundToggle.isOn = SettingManager.Instance.isESChecked;
        backgroundAudioSlider.value = SoundManager.Instance.backgroundAudioSource.volume;
        playerUIAlphaSlider.value = SettingManager.Instance.settingManagerData.playerUIAlpha;
        //backgroundSoundToggle.isOn = SettingManager.Instance.isBGSChecked;
        miniMapToggle.isOn = SettingManager.Instance.isMMChecked;

        if (!SettingManager.Instance.isMontiorChecked)
        {
            monitorToggle.isOn = false;
            monitorToggleTmp.isOn = true;
        }

        if (miniMapToggle.isOn)
        {
            miniMapCamera.gameObject.SetActive(true);
        }
        else
        {
            miniMapCamera.gameObject.SetActive(false);
        }

         moveButtonToggle[0].isOn = SettingManager.Instance.isMBChecked;
        //ChangeMonitor();
        ChangePlayerUiAlpha();
        settingPage.gameObject.SetActive(false);
    }

    public void MoveBtnChange()
    {
        SettingManager.Instance.isMBChecked = moveButtonToggle[0].isOn;
        moveButtonToggle[1].isOn = !moveButtonToggle[0].isOn;
        var leftButton = moveButton[0].GetComponent<RectTransform>().anchoredPosition;
        var rightButton = moveButton[1].GetComponent<RectTransform>().anchoredPosition;
        if(!SettingManager.Instance.isMBChecked)
        {
            moveButton[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(leftButton.x, 120);
            moveButton[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(rightButton.x, 120);
            moveButtonToggle[1].GetComponent<Toggle>().enabled = false;
            moveButtonToggle[0].GetComponent<Toggle>().enabled = true;
        }
        else
        {
            moveButton[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(leftButton.x, 50);
            moveButton[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(rightButton.x, 50);
            moveButtonToggle[0].GetComponent<Toggle>().enabled = false;
            moveButtonToggle[1].GetComponent<Toggle>().enabled = true;
        }

    }
    public void MoveBtnChange1()
    {
        SettingManager.Instance.isMBChecked = moveButtonToggle[0].isOn;
        moveButtonToggle[0].isOn = !moveButtonToggle[1].isOn;
        var leftButton = moveButton[0].GetComponent<RectTransform>().anchoredPosition;
        var rightButton = moveButton[1].GetComponent<RectTransform>().anchoredPosition;


    }

    public void UpdateMineralTime(int index)
    {
        if(ClickerManager.Instance.drillLevel <= index)
        {
            mineralTime[index].text = "";
        }
        else
        mineralTime[index].text = (ClickerManager.Instance.remainTime[index] - AchievementManager.Instance.achievementManagerData.clickerMinusTime).ToString();
    }

    public void OpenCashStoreIntroduce(int index)
    {
        if (CashStoreManager.Instance.drillLevel == 12 && index == 0)
        {
            cashStoreIntroduces[index].gameObject.SetActive(true);
            UpdateCashStoreCostUI(index);
            cashStoreIntroduces[index + 1].gameObject.SetActive(false);
            cashStoreBuyBtn[0].SetActive(false);
        }
        else if (CashStoreManager.Instance.drillLevel > 0 && index ==0)
        {
            cashStoreIntroduces[index+1].gameObject.SetActive(true);
            UpdateCashStoreCostUI(index+1);
            cashStoreIntroduces[index].gameObject.SetActive(false);
        }
        else if(index == 0)
        {
            cashStoreIntroduces[index].gameObject.SetActive(true);
            UpdateCashStoreCostUI(index);
        }

        if (CashStoreManager.Instance.clickerLevel == 12 && index == 2)
        {
            cashStoreIntroduces[index].gameObject.SetActive(true);
            UpdateCashStoreCostUI(index);
            cashStoreIntroduces[index + 1].gameObject.SetActive(false);
            cashStoreBuyBtn[1].SetActive(false);
        }
        else if (CashStoreManager.Instance.clickerLevel > 0 && index == 2)
        {
            cashStoreIntroduces[index + 1].gameObject.SetActive(true);
            UpdateCashStoreCostUI(index + 1);
            cashStoreIntroduces[index].gameObject.SetActive(false);
        }
        else if(index == 2)
        {
            cashStoreIntroduces[index].gameObject.SetActive(true);
            UpdateCashStoreCostUI(index);
        }

        if (CashStoreManager.Instance.boosterLevel == 16 && index == 4)
        {
            cashStoreIntroduces[index].gameObject.SetActive(true);
            UpdateCashStoreCostUI(index);
            cashStoreIntroduces[index + 1].gameObject.SetActive(false);
            cashStoreBuyBtn[2].SetActive(false);
        }
        else if(CashStoreManager.Instance.boosterLevel >= 0 && index == 4)
        {
            cashStoreIntroduces[index+1].gameObject.SetActive(true);
            UpdateCashStoreCostUI(index+1);
        }

        if(index == 6)
        {
            cashStoreIntroduces[index].gameObject.SetActive(true);
            UpdateCashStoreCostUI(index);
        }
    }

    public void CloseCashStoreIntroduce(int index)
    {
        cashStoreIntroduces[index].gameObject.SetActive(false);
    }

    public void UpdateMonsterRewardUI(int reward)
    {
        if (reward > 5999)
            monsterRewardImage.sprite = money;
        else
            monsterRewardImage.sprite = adamant;
        MonsterRewardText.text = string.Format("{0:N0}", reward);
        //reward = 0;
    }

    public void OpenMonsterRewardUI()
    {
        rewardPage.gameObject.SetActive(true);

    }

    public void CloseMonsterRewardUI()
    {
        rewardPage.gameObject.SetActive(false);

    }

    public void OpenGNSceneUI()
    {
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = true;
        if (GameManager.Instance.currentSceneIndex.Equals(SceneManager.sceneCountInBuildSettings - 1))
        {
            if(!GameManager.Instance.isGetKey[GameManager.Instance.currentSceneIndex - 1])
            GNSceneUI.gameObject.SetActive(true);
            else
                updatePanel.gameObject.SetActive(true);
        }
        else
        {
            GNSceneUI.gameObject.SetActive(true);
        }
    }

    public void CloseUpdatePanel()
    {
        updatePanel.gameObject.SetActive(false);
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = false;
    }

    public void CloseGNSceneUI()
    {
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = false;
        GNSceneUI.gameObject.SetActive(false);
    }

    public void OpenGPSceneUI()
    {
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = true;
        GPSceneUI.gameObject.SetActive(true);
    }

    public void CloseGPSceneUI()
    {
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = false;
        GPSceneUI.gameObject.SetActive(false);
    }
    /*--------------------------------------------*/
    public void ClickExitBtn(GameObject gameObject)
    {
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = false;
        gameObject.SetActive(false);
    }

    public void ClickExitBtnTotal()
    {
        exitUI.gameObject.SetActive(false);
        opendUI.gameObject.SetActive(false);
        introducePanel.gameObject.SetActive(false);
        UIManager.Instance.storeTemporaryText.gameObject.SetActive(false);
        GameManager.Instance.isGameStop = false;
    }

    public void ClickOpenUI(GameObject gameobj)
    {
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = true;
        gameobj.gameObject.SetActive(true);
    }

    public void OpenTutorialPanel()
    {
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = true;
        //exitUI.gameObject.SetActive(true);
        tutorialPanel.gameObject.SetActive(true);
        //opendUI = tutorialPanel;
    }

    public void CloseTutorialPanel()
    {
        SoundManager.Instance.clickAudioSource.Play();
        if (player.playerData.isFirstStart)
        {
            tutorialFirstPanel.gameObject.SetActive(true);
        }
        else
        {
            tutorialPanel.gameObject.SetActive(false);
            UIManager.Instance.storeTemporaryText.gameObject.SetActive(false);
            GameManager.Instance.isGameStop = false;
        }
    }

    public void OkayTutorialFirstPanel()
    {
        SoundManager.Instance.clickAudioSource.Play();
        player.playerData.isFirstStart = false;
        tutorialPanel.gameObject.SetActive(false);
        tutorialFirstPanel.gameObject.SetActive(false);
        SaveManager.Instance.Save();
    }

    public void OpenInventory()
    {
        SoundManager.Instance.clickAudioSource.Play();
        storePanel.gameObject.SetActive(true);
        storeBackground.gameObject.SetActive(true);
        //Store.gameObject.SetActive(false);
        exitUI.gameObject.SetActive(true);
        opendUI = storePanel;
        UpdateStoreInventoryUI();
        UpdateCurrentCap();
        UpdateCurrentDrill();
        UpdateEquipmentCostUI();
        UpdateStoreDrillAndCapUpgradeSub();
        /*
        if(itemManager.storeTicket > 0)
        {
            storeTicketBtn.gameObject.SetActive(true);
        }
        else
        {
            storeTicketBtn.gameObject.SetActive(false);
        }
        */
        if (itemManager.isBuyPermanentStoreTicket)
        {
            storeBackground.gameObject.SetActive(false);
        }
    }

    public void UpdateStoreDrillAndCapUpgradeSub()
    {
        if(player.drillLevel < player.maxDrillLevel)
        {
            if (player.drillLevel <= 6)
                storeSubText[0].text = "드릴 파워 : " + ((int)((player.miningPower + 0.01f) * 10) * 10 + 50);//(int)(0.5f*100);
            else
                storeSubText[0].text = "드릴 파워 : " + ((int)((player.miningPower + 0.01f) * 10) * 10 + 60);//(int)(0.5f*100);
        }

        /*
        if (player.drillLevel <= 6)
        {
            storeSubText[0].text = "드릴 파워 : +" + player.miningPower * 100;//(int)(0.5f*100);
        }
        else if(player.drillLevel > 6)
        {
            storeSubText[0].text = "파워 +" + (int)(0.6f * 100);
        }
        */
        if (player.capLevel < player.maxCapLevel)
        {
            storeSubText[1].text = "산소량 : " + (player.maxOxygen + 10) + "\n방어력 : " + Mathf.FloorToInt(player.defencePower + 7.5f);
            //storeSubText[2].text = "방어력 : " + Mathf.FloorToInt(player.defencePower + 7.5f);//+ player.defencePower;
        }

    }

    public IEnumerator TalkBoxFollowPlayer()
    {
        while (talkBox.gameObject.activeInHierarchy)
        {
            //Debug.Log("dd");
            talkBox.transform.position = player.transform.position + Vector3.up*2 + Vector3.right*0.7f;
            yield return null;
        }
        
    }

    public void OpenNoKeyPanel()
    {
        noKeyPanel.gameObject.SetActive(true);
    }
    public void ExitNoKeyPanel()
    {
        SoundManager.Instance.clickAudioSource.Play();
        noKeyPanel.gameObject.SetActive(false);
        GNSceneUI.gameObject.SetActive(false);
        GameManager.Instance.isGameStop = false;
    }

    public void UpdateStageText()
    {
        stageText.text = "stage" + GameManager.Instance.currentSceneIndex.ToString();
    }

    public void OpenMoneyBoxPanel()
    {
        GameManager.Instance.isGameStop = true;
        if (MoneyBox.Instance.count >= 300 && MoneyBox.Instance.canGet)
        { 
            //Debug.Log("yy");
            SoundManager.Instance.clickAudioSource.Play();
            moneyBoxPanel.gameObject.SetActive(true);
            UpdateMoneyRewardText();
        }
        else
        {
            coolTimePanel.gameObject.SetActive(true);
            SoundManager.Instance.clickFailAudioSource.Play();
        }
    }

    public void CloseCoolTimePanel()
    {
        coolTimePanel.gameObject.SetActive(false);
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = false;
    }

    public void CloseMoneyBoxPanel()
    {

            SoundManager.Instance.clickAudioSource.Play();
            GameManager.Instance.isGameStop = false;
            moneyBoxPanel.gameObject.SetActive(false);
        

    }

    public void OpenAdamantBoxPanel()
    {
        GameManager.Instance.isGameStop = true;
        if (AdamantBox.Instance.count >= 300)
        {
            SoundManager.Instance.clickAudioSource.Play();
            
            adamantBoxPanel.gameObject.SetActive(true);
            UpdateAdamantRewardText();
        }  
        else
        {
            coolTimePanel.gameObject.SetActive(true);
            SoundManager.Instance.clickFailAudioSource.Play();
        }
    }

    public void CloseAdamantBoxPanel()
    {
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = false;
        adamantBoxPanel.gameObject.SetActive(false);
    }

    public void UpdateMoneyRewardText()
    {
        moneyRewardText.text = string.Format("{0:N0}", MoneyBox.Instance.reward);
    }

    public void UpdateAdamantRewardText()
    {
        adamantRewardText.text = string.Format("{0:N0}", AdamantBox.Instance.reward);
    }

    public IEnumerator ChangeMoneyWaitText()
    {
        moneyWaitText.text = "기다리셨군요!";
        for(int i=0;i<5;i++)
            yield return oneSec;
        moneyWaitText.text = "기다렸어요!";
    }

    public void OpenRainbowPanel()
    {
        rainbowPanel.gameObject.SetActive(true);
        GameManager.Instance.isGameStop = true;
    }

    public void UpdateRainbowRewardText(int num)
    {
        rainbowRewardText.text = "을 " + num.ToString()+"개 획득했습니다!";
    }

    public void CloseRainbowPanel()
    {
        rainbowPanel.gameObject.SetActive(false);
        SoundManager.Instance.clickAudioSource.Play();
        GameManager.Instance.isGameStop = false;
    }

    public void UpdateCurrentDrill()
    {

            if (player.drillLevel.Equals(1))
            {
                currentDrillImage.sprite = storeDrillImages[0];
            }
            else
            {
                currentDrillImage.sprite = storeDrillImages[(player.drillLevel - 2) * 5 + 1];//배열 첫번째에 하나 꼈음
            }

            currentDrillLevelText.text = "Level : " + player.drillLevel;
            currentDrillPowerText.text = "드릴 파워 : " + (int)((player.miningPower + 0.01f) * 10) * 10;


    }

    public void UpdateCurrentCap()
    {

            currentCapImage.sprite = storeCapImages[(player.capLevel - 1) * 4];
            currentCapLevelText.text = "Level : " + player.capLevel;
            currentCapPowerText.text = "산소량 : " + player.maxOxygen +"\n방어력 : " + player.defencePower;

        
    }

    public void UpdatePlayerText()
    {
        if (!talkBox.activeInHierarchy)
        {
            int rand = Random.Range(0, 4);

            talkBoxCoroutine = StartCoroutine(ShowPlayerText(rand));
        }
       
        
    }

    IEnumerator ShowPlayerText(int rand)//key border와 겹칠경우 예상해야됨
    {
        switch (rand)
        {
            case 0:
                playerText.text = "화이팅!";
                break;
            case 1:
                playerText.text = "조금만 더\n힘내자!";
                break;
            case 2:
                playerText.text = "멈추지 말자!";
                break;
            case 3:
                playerText.text = "포기하지\n말자!";
                break;
        }

        talkBox.gameObject.SetActive(true);

        //StartCoroutine(TalkBoxFollowPlayer());

        for (int i=0;i<4;i++)
        yield return oneSec;

        talkBox.gameObject.SetActive(false);

        talkBoxCoroutine = null;
    }
    /*
    public IEnumerator ShowTalkBox(string str)
    {

        playerText.text = str;

        talkBox.gameObject.SetActive(true);

        for (int i = 0; i < 4; i++)
            yield return oneSec;


        talkBox.gameObject.SetActive(false);

        talkBoxCoroutine = null;
    }
    */
    public void OpenKeyPanel()
    {
        keyPanel.gameObject.SetActive(true);
    }

    public void CloseKeyPanel()
    {
        SoundManager.Instance.clickAudioSource.Play();
        keyPanel.gameObject.SetActive(false);
    }

    public void SaveMessage()
    {
        Vector3 tempPosition = GameObject.Find("Player").transform.position;
        tempPosition = new Vector3(tempPosition.x, tempPosition.y + 1, tempPosition.z);
        var screenPos = Camera.main.WorldToScreenPoint(tempPosition);
        saveMsg.GetComponent<RectTransform>().position = screenPos;
        saveMsg.SetActive(true);
        saveMsgText.color = new Color(saveMsgText.color.r, saveMsgText.color.g, saveMsgText.color.b, 1f);
        saveMsgBackground.color = new Color(saveMsgBackground.color.r, saveMsgBackground.color.g, saveMsgBackground.color.b, 1f);
        StartCoroutine("FadeOutSaveMsg");
    }

    public IEnumerator FadeOutSaveMsg()
    {
        var image = saveMsgText;
        var background = saveMsgBackground;
        if (image.color.a >= 0.99f && background.color.a >= 0.99f)
        {
            while (image.color.a > 0)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.01f);
                background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a - 0.01f);
                yield return null;
            }
                saveMsg.SetActive(false);
        }

    }
    public void OnStoreSellPanel()
    {
        storeSellPanel.gameObject.SetActive(true);
    }

    public void OffStoreSellPanel()
    {
        storeSellPanel.gameObject.SetActive(false);
    }

    public void UpdateIntroducePanel(Sprite sprite, string str, int cost)
    {
        introduceImage.sprite = sprite;
        introduceNameText.text = str;
        introducePriceText.text = "판매 가격 : " + cost;
    }

    public void UpdateAllSellText(int price)
    {
        allSellText.text = "총 판매 가격 : " + price;
    }

    public void ChangeBackgroundAudioVolume()
    {
        SoundManager.Instance.backgroundAudioSource.volume = backgroundAudioSlider.value;
    }
    public void ChangePlayerUiAlpha()
    {
        Color tmpC = new Color(1, 1, 1, playerUIAlphaSlider.value);

        for (int i = 0; i < playerUI.Length; i++)
            playerUI[i].color = tmpC;

        minimapImage.color = tmpC;
    }

    public void OpenCloudPanel()
    {
        SoundManager.Instance.clickAudioSource.Play();
        cloudPanel.gameObject.SetActive(true);
        //SaveCompleteObjFadeOutF();
#if UNITY_ANDROID
        cloudSaveText.text = "클라우드 저장기능은 '구글 플레이 게임'이\n설치되어야 사용이 가능합니다.";

#elif UNITY_IOS
        cloudSaveText.text = "클라우드 저장기능은 'iCloud -> iCloud Drive'가\n켜져 있어야 합니다..";
#endif
    }

    public void CloseCloudPanel()
    {
        SoundManager.Instance.clickAudioSource.Play();
        cloudPanel.gameObject.SetActive(false);
    }

    public void SaveCompleteObjFadeOutF()
    {
        
            StartCoroutine(SaveCompleteObjFadeOut());
        
    }

    IEnumerator SaveCompleteObjFadeOut()
    {
        

        Color tmpC = new Color(saveCompleteObj.color.r, saveCompleteObj.color.g, saveCompleteObj.color.b,0);
        Color tmpT = new Color(0,0,0, 0);
        

        
        

        while(saveCompleteObj.color.a > 0.01f)
        {
            saveCompleteObj.color = Color.Lerp(saveCompleteObj.color, tmpC, Time.deltaTime);
            saveCompleteText.color = Color.Lerp(saveCompleteText.color, tmpT, Time.deltaTime);
            yield return null;
        }

        saveCompleteObj.gameObject.SetActive(false);
        CloudScript.Instance.isClick = false;
    }

    public void ClosePausePanel()
    {
        SoundManager.Instance.clickAudioSource.Play();
        Time.timeScale = 1;
        pausePanel.gameObject.SetActive(false);
    }

    public void DelayedClosePausePanel()
    {
        Invoke("ClosePausePanel", 1f);
    }

    public void ClickRateNow()
    {

#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.Flatworld.miningexample");
#elif UNITY_IOS
        Application.OpenURL("market://details?id=com.Flatworld.Dontgiveup");
#endif

    }

    public void DrillBuffAD()
    {
        if (!drillBuff)
        {
            AdsManager.Instance.admob_Rewards[3].ShowRewardedAd();
        }
    }

    public void DrillBuffAdamant()
    {
        if (GameManager.Instance.adamant >= 200)
        {
            GameManager.Instance.adamant -= 200;
            UIManager.Instance.UpdateAdamantText();
            StartCoroutine(CountDrillBuff());
        }
    }

    public IEnumerator CountDrillBuff()
    {
        player.miningPowerBuffCoefficient += 1;
        drillBuff = true;
        ADBtns[0].fillAmount = 0;
            ADBtns[0].transform.GetComponent<Button>().enabled = false;
        for (int i = 0; i < 300; i++)
        {
            yield return oneSec;
            ADBtns[0].fillAmount += 0.00333f;
        }

        ADBtns[0].transform.GetComponent<Button>().enabled = true;
        player.miningPowerBuffCoefficient -= 1;
        drillBuff = false;

    }

    public void DynamiteBuffAD()
    {
        if (!dynamiteBuff)
        {
            AdsManager.Instance.admob_Rewards[5].ShowRewardedAd();
        }
    }

    public void DynamiteBuffAdamant()
    {
        if (GameManager.Instance.adamant >= 200)
        {
            GameManager.Instance.adamant -= 200;
            UIManager.Instance.UpdateAdamantText();
            StartCoroutine(CountDynamiteBuff());
        }
    }

    public IEnumerator CountDynamiteBuff()
    {
        ItemDB.Instance.Range = 2;
        dynamiteBuff = true;
        ADBtns[1].fillAmount = 0;
            ADBtns[1].transform.GetComponent<Button>().enabled = false;
        for (int i = 0; i < 300; i++)
        {
            yield return oneSec;
            ADBtns[1].fillAmount += 0.00333f;
        }

        ADBtns[1].transform.GetComponent<Button>().enabled = true;


        ItemDB.Instance.Range = 0;
        dynamiteBuff = false;

    }
    public void OxygenBuffAD()
    {
        if (!oxygenBuff)
        {
            AdsManager.Instance.admob_Rewards[8].ShowRewardedAd();
        }
    }

    public void OxygenBuffAdamant()
    {
        if (GameManager.Instance.adamant >= 200)
        {
            GameManager.Instance.adamant -= 200;
            UIManager.Instance.UpdateAdamantText();
            StartCoroutine(CountOxygenBuff());
        }
    }

    public IEnumerator CountOxygenBuff()
    {
        player.OxygenRemain = player.maxOxygen;
        oxygenBuff = true;
        ADBtns[2].fillAmount = 0;
            ADBtns[2].transform.GetComponent<Button>().enabled = false;
        for (int i = 0; i < 300; i++)
        {
            yield return oneSec;
            ADBtns[2].fillAmount += 0.00333f;
        }

        ADBtns[2].transform.GetComponent<Button>().enabled = true;


        oxygenBuff = false;

    }
    public void BoosterBuffAD()
    {
        if (!boosterBuff)
        {
            AdsManager.Instance.admob_Rewards[9].ShowRewardedAd();
        }
    }
    public void BoosterBuffAdamant()
    {
        if (GameManager.Instance.adamant >= 200)
        {
            GameManager.Instance.adamant -= 200;
            UIManager.Instance.UpdateAdamantText();
            StartCoroutine(CountBoosterBuff());
        }
    }

    public IEnumerator CountBoosterBuff()
    {
        player.fuelRemain = player.maxFuel;

        boosterBuff = true;
        ADBtns[3].fillAmount = 0;
            ADBtns[3].transform.GetComponent<Button>().enabled = false;
        for (int i = 0; i < 300; i++)
        {
            yield return oneSec;
            ADBtns[3].fillAmount += 0.00333f;
        }

        ADBtns[3].transform.GetComponent<Button>().enabled = true;

        boosterBuff = false;

    }
}
