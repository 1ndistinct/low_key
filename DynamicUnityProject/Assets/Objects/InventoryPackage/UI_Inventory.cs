using System;
using System.Collections;
using System.Collections.Generic;
using Unity.InteractiveTutorials;
using UnityEngine;
using UnityEngine.UI;


public class UI_Inventory : MonoBehaviour
{
    //ItemAssets
    //
    public List<Sprite> sprites;
    public Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();
    
    private Inventory inventory;
    public GameObject itemSlotContainer;
    public GameObject itemSlotTemplate;
    
    public float itemSLotCellsize = 30f;


    private void MoveSprites(Sprite sprite) 
    {
        spriteDict.Add(sprite.name, sprite); 
    }
    private void Awake()
    {
        sprites.ForEach(sprite =>MoveSprites(sprite));
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in gameObject.transform)
        {
            foreach (Transform grandchild in child)
            {

                if (grandchild != itemSlotTemplate.transform)
                    Destroy(grandchild.gameObject);
               
            }
        }
        inventory.GetItemList().ForEach(item => {
            
            GameObject InventoryItem = Instantiate(itemSlotTemplate, itemSlotContainer.transform);
            Image image = InventoryItem.transform.Find("ItemSprite").GetComponent<Image>();
            if (getSprite(item) != null)
            {
                image.sprite = getSprite(item);
                InventoryItem.gameObject.SetActive(true);
            }

        });
    }

    private Sprite getSprite(Item item)
    {
        if (Enum.IsDefined(typeof(Item.ResourceItems), item.ItemType) && spriteDict.ContainsKey(((Item.ResourceItems)item.ItemType).ToString()))
            return spriteDict[((Item.ResourceItems)item.ItemType).ToString()];
        
        else if (Enum.IsDefined(typeof(Item.GemItems), item.ItemType) && spriteDict.ContainsKey(((Item.GemItems)item.ItemType).ToString()))
            return spriteDict[((Item.GemItems)item.ItemType).ToString()];
        
        else if (Enum.IsDefined(typeof(Item.ComponentItems), item.ItemType) && spriteDict.ContainsKey(((Item.ComponentItems)item.ItemType).ToString()))
            return spriteDict[((Item.ComponentItems)item.ItemType).ToString()];
        
        else if (Enum.IsDefined(typeof(Item.ConsumableItems), item.ItemType) && spriteDict.ContainsKey(((Item.ConsumableItems)item.ItemType).ToString()))
            return spriteDict[((Item.ConsumableItems)item.ItemType).ToString()];
        
        else return null;
    }
}
