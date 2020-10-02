using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public class Resources : Item
    {
        
        public enum ResourceItems
        {
            Purple,
            Green,
            Yellow,
            Blue,
        }
    }
    public class Consumables : Item
    {
        public enum ConsumableItems
        {
            HealthPot,
            ManaPot,
        }
    }
    public class Gems : Item
    {
        public enum GemItems
        {
            Gem1,
            Gem2,
            Gem3,
        }
    }
    public class Components : Item
    {
        public enum ComponentItems
        {
            Component1,
            Component2,
            Component3,
        }
    }

    public Item item;
    public Gems.GemItems gems;
    public Resources.ResourceItems resources;
    public Components.ComponentItems components;
    public Consumables.ConsumableItems consumables;

    //ItemAttributes
    public int amount;
    /// <summary>
    /// ItemTypes are:
        /// "Resource"
        /// "Component"
        /// "Gem"
        /// "Consumable"
    /// </summary>
    public String ItemType;
    public bool isStackable;
    public Sprite ItemSprite;

    public Sprite GetSprite()
    {
        /* if (item.ItemType == "Resource") 
         {
             switch (resources)
             {
                 default:
                 case Resources.ResourceItems.Purple: return ItemAssets.Instance.ResourceSprite;
                 case Resources.ResourceItems.Yellow: return ItemAssets.Instance.ResourceSprite;
                 case Resources.ResourceItems.Green: return ItemAssets.Instance.ResourceSprite;
                 case Resources.ResourceItems.Blue: return ItemAssets.Instance.ResourceSprite;
             }
         }
         if (item.ItemType =="Gems")
         {
             switch (gems)
             {
                 default:
                 case Gems.GemItems.Gem1: return ItemAssets.Instance.GemSprite;
                 case Gems.GemItems.Gem2: return ItemAssets.Instance.GemSprite;
                 case Gems.GemItems.Gem3: return ItemAssets.Instance.GemSprite;
             }
         }        
         if (item.ItemType =="Components")
         {
             switch (components)
             {
                 default:
                 case Components.ComponentItems.Component1: return ItemAssets.Instance.ComponentSprite;
                 case Components.ComponentItems.Component2: return ItemAssets.Instance.ComponentSprite;
                 case Components.ComponentItems.Component3: return ItemAssets.Instance.ComponentSprite;
             }
         }
         if (item.ItemType == "Consumables")
         {
             switch (consumables)
             {
                 default:
                 case Consumables.ConsumableItems.HealthPot: return ItemAssets.Instance.ConsumableSprite;
                 case Consumables.ConsumableItems.ManaPot: return ItemAssets.Instance.ConsumableSprite;
             }
         }
         else return ItemAssets.Instance.NullSprite;*/
        return ItemSprite;
        
    }

}
