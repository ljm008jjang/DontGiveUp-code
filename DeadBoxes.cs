using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBoxes : MonoBehaviour
{
    public DeadBox[] deadBoxArray;
    public DeadBoxesData deadBoxesData;

}

[System.Serializable]
public class DeadBoxesData
{
    public List<Vector3> deadBoxPoses;
    public List<DeadBoxItemData> itemDatas;
    public List<int> money;
    public List<bool> isOn;
}

[System.Serializable]
public class DeadBoxItemData
{
    public string itemName;

    public int index;
}

