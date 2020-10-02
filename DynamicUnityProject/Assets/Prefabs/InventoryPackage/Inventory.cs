using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Inventory 
{
    public List<Item> itemList;
    public event EventHandler OnItemListChanged;
    public Inventory() {
        itemList = new List<Item>();

        AddItem(new Item { resources = Item.Resources.ResourceItems.Green, amount = 1,ItemType = "Resource" });
        AddItem(new Item { resources = Item.Resources.ResourceItems.Blue, amount = 1, ItemType = "Resource" });
        AddItem(new Item { resources = Item.Resources.ResourceItems.Purple, amount = 1, ItemType = "Resource" });
        AddItem(new Item { gems = Item.Gems.GemItems.Gem1, amount = 1,ItemType ="Gem" });
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
   
}
