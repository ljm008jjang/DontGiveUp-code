using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    private static ItemDB _Instance;

    public static ItemDB Instance
    {
        get
        {
            return _Instance;
        }
    }

    public Bomb bombPrefab;
    public Dynamite dynamitePrefab;
    public OxygenCapsule oxygenCapsulePrefab;
    public AidPack aidPackPrefab;
    public Teleport teleportPrefab;
    public StoreTicket storeTicketPrefab;
    public Mineral coalPrefab;
    public Mineral goldPrefab;
    public Mineral bronzePrefab;
    public Mineral silverPrefab;
    public Mineral crystalPrefab;
    public Mineral amethystPrefab;
    public Mineral diamondPrefab;
    public Mineral emeraldPrefab;
    public Mineral morionPrefab;
    public Mineral opalPrefab;
    public Mineral pinkdiamondPrefab;
    public Mineral platinumPrefab;
    public Mineral rubyPrefab;
    public Mineral sapphirePrefab;
    public Mineral blackdiamondPrefab;
    public Mineral radiumPrefab;
    public Mineral scandiumPrefab;
    public Mineral uraniumPrefab;
    public Mineral californiumPrefab;
    public Mineral plutoniumPrefab;
    public Mineral franciumPrefab;
    public Mineral poloniumPrefab;
    /*
    public CapY CapYPrefab;
    public CapO CapOPrefab;
    public Cap CapRPrefab;
    public Drill drillYPrefab;
    public Drill drillOPrefab;
    public Drill drillRPrefab;
    */
    public Key keyPrefab;

    public List<Mineral> mineralPrefabs;
    public Item[] itemPrefabs;

    public Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();
    public int Range = 0;
    private void Awake()
    {
        

        
        _Instance = this;

    }
}
