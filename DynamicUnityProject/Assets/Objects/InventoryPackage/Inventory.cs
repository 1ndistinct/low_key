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

        AddItem(new Item((int)Item.ResourceItems.Green,true,1));
        AddItem(new Item((int)Item.ResourceItems.Blue, true, 1));
        AddItem(new Item((int)Item.ResourceItems.Purple, true, 1));
        AddItem(new Item((int)Item.GemItems.Gem1,false,1));
        AddItem(new Item((int)Item.GemItems.Gem2, false, 1));
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
