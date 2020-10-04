using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public Item item;
    /*   public GemItems gems;
       public ResourceItems resources;
       public ComponentItems components;
       public ConsumableItems consumables;*/

    //ItemAttributes

    /// <summary>
    /// ItemTypes are:
    /// "Resource"
    /// "Component"
    /// "Gem"
    /// "Consumable"
    /// </summary>
    public const int ResourceIndex = 1;
    public const int ComponentIndex = 10;
    public const int ConsumableIndex = 5;
    public const int GemIndex = 7;

    public int ItemType;
    public bool isStackable;
    public int amount;

    public Item(int ItemType, bool isStackable,int amount) 
    {
        this.ItemType = ItemType;
        this.isStackable = isStackable;
        this.amount = amount;
    }
    
    public enum ResourceItems
    {
        Purple = ResourceIndex,
        Green,
        Yellow,
        Blue,
    }


    public enum ConsumableItems
    {
        HealthPot = ConsumableIndex,
        ManaPot,
    }


    public enum GemItems
    {
        Gem1 = GemIndex,
        Gem2,
        Gem3,
    }


    public enum ComponentItems
    {
        Component1 = ComponentIndex,
        Component2,
        Component3,
    }






}
