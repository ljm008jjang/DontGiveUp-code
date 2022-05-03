using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountMineral : MonoBehaviour
{
    GameObject[] minerals;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5000; i++)
        {
            Debug.Log(this.transform.GetChild(i).name);
        }
    }
}
