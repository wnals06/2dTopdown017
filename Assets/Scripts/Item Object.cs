using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] ItemSo data;  // Inspector  �巡��

    public int GetPoint()
    {
        return data.point;   // ItemSo�� point �� ��ȯ
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
