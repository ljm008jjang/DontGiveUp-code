using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    private static TileManager _Instance;

    public static TileManager Instance
    {
        get
        {
            return _Instance;
        }
    }


    public Tilemap map;
    public Tilemap OnlyDynamiteMap;
    public Tilemap UnMiningableMap;
    public Tilemap MineralMap;
    
    public List<TileData> tileDatas;

    public Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {

         _Instance = this;

        
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach(var tileData in tileDatas)
        {
            foreach (var tileBase in tileData.tileBases)
            {
                dataFromTiles.Add(tileBase, tileData);
            }    
            
        }


    }

    public void GetMineralInfo()
    {
        List<int> list = new List<int>();

        for(int i = 0; i < ItemDB.Instance.mineralPrefabs.Count; i++)
        {
            list.Add(0);
        }

        MineralContainer mc = MineralMap.GetComponent<MineralContainer>();

        for(int i = 0; i < mc.minerals.Count; i++)
        {
            for(int j = 0; j < ItemDB.Instance.mineralPrefabs.Count; j++)
            {
                if(!ReferenceEquals( mc.minerals[i],null) && mc.minerals[i].itemName.Equals(ItemDB.Instance.mineralPrefabs[j].itemName))
                {
                    list[j]++;
                    break;
                }
            }
            
        }

        int all = 0;
        for(int i = 0; i < ItemDB.Instance.mineralPrefabs.Count; i++)
        {
            if (!list[i].Equals(0))
            {
                Debug.Log(ItemDB.Instance.mineralPrefabs[i].itemName + " : " + list[i]);
                all += list[i];
            }
        }

        Debug.Log("All : " + all);
    }

    public void BreakCell(Vector3Int position)
    {
        map.SetTile(position, null);
        QuestManager.Instance.questManagerData.brokenBlock++;
        //Debug.Log(QuestManager.Instance.questManagerData.brokenBlock);
        QuestManager.Instance.questManagerData.stageBorkenBlock[GameManager.Instance.currentSceneIndex-1]++;

        UIManager.Instance.blockHit.transform.position = position + new Vector3(0.5f,0.5f,0);
        UIManager.Instance.blockHit.Play();
        if ((QuestManager.Instance.questManagerData.brokenBlock % 50).Equals(0))
        {
            UIManager.Instance.UpdatePlayerText();
            
        }
    }

    public void BreakAllCell(Vector3Int position)
    {
        map.SetTile(position, null);
        OnlyDynamiteMap.SetTile(position, null);
        QuestManager.Instance.questManagerData.brokenBlock++;
        //Debug.Log(QuestManager.Instance.questManagerData.brokenBlock);
        QuestManager.Instance.questManagerData.stageBorkenBlock[GameManager.Instance.currentSceneIndex-1]++;
        if ((QuestManager.Instance.questManagerData.brokenBlock % 50).Equals(0))
        {
            UIManager.Instance.UpdatePlayerText();
            
        }
    }

    public void ChangeCell(Vector3Int position,TileBase tileBase)
    {
        map.SetTile(position, tileBase);
    }

    public TileData GetTileData(Vector3Int tilePosition)
    {
        TileBase tile = map.GetTile(tilePosition);

        if (tile != null)
            return dataFromTiles[tile];
        else
            return null;
    }
}
