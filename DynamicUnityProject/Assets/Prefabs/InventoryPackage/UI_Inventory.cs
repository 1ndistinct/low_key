using System.Collections;
using System.Collections.Generic;
using Unity.InteractiveTutorials;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    //ItemAssets
    public Sprite ResourceSprite;
    public Sprite ResourceSpriteBlue;
    public Sprite ResourceSpriteYellow;
    public Sprite ResourceSpriteGreen;
    public Sprite ResourceSpritePurple;
    public Sprite GemSprite;
    public Sprite ComponentSprite;
    public Sprite ConsumableSprite;
    public Sprite NullSprite;
    //

    private Inventory inventory;

    public GameObject itemSlotContainer;
    public GameObject itemSlotTemplate;
    
    public float itemSLotCellsize = 30f;

    private void Awake()
    {
        
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

                if (grandchild == itemSlotTemplate.transform)
                {
                    print(grandchild);
                }
                else
                {
                    //print("this");
                    Destroy(grandchild.gameObject);
                }
            }
        }

        foreach (Item item in inventory.GetItemList())
        {
            
            GameObject InventoryItem = Instantiate(itemSlotTemplate,itemSlotContainer.transform);
            
            InventoryItem.gameObject.SetActive(true);
            Image image = InventoryItem.transform.Find("ItemSprite").GetComponent<Image>();
            image.sprite = getSprite(item);
        }

    }

    private Sprite getSprite(Item item)
    {
        if (item.ItemType == "Resource")
        {
            switch (item.resources)
            {
                default:
                case Item.Resources.ResourceItems.Purple: return ResourceSprite;
                case Item.Resources.ResourceItems.Yellow: return ResourceSprite;
                case Item.Resources.ResourceItems.Green: return ResourceSprite;
                case Item.Resources.ResourceItems.Blue: return ResourceSprite;
            }
        }
        if (item.ItemType == "Gem")
        {
            switch (item.gems)
            {
                default:
                case Item.Gems.GemItems.Gem1: return GemSprite;
                case Item.Gems.GemItems.Gem2: return GemSprite;
                case Item.Gems.GemItems.Gem3: return GemSprite;
            }
        }
        if (item.ItemType == "Component")
        {
            switch (item.components)
            {
                default:
                case Item.Components.ComponentItems.Component1: return ComponentSprite;
                case Item.Components.ComponentItems.Component2: return ComponentSprite;
                case Item.Components.ComponentItems.Component3: return ComponentSprite;
            }
        }
        if (item.ItemType == "Consumable")
        {
            switch (item.consumables)
            {
                default:
                case Item.Consumables.ConsumableItems.HealthPot: return ConsumableSprite;
                case Item.Consumables.ConsumableItems.ManaPot: return ConsumableSprite;
            }
        }
        else return NullSprite;
    }
}
