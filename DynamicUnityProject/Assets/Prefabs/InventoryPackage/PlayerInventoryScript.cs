using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryScript : MonoBehaviour
{
    [SerializeField] private UI_Inventory uI_Inventory;
    private Inventory inventory;
    private void Awake()
    {
        inventory = new Inventory();
        uI_Inventory.SetInventory(inventory);
    }
    // Start is called before the first frame update
    void Start()
    {
        print(inventory.GetItemList()[0].ItemType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
