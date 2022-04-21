using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemDatabase : MonoBehaviour
{
    public class StoreItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ButtonName { get; set;}
        public int Cost { get; set; }
    }

    public class CurrencyBundle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ButtonName { get; set; }
        public float Cost { get; set; }
    }



    public static void Main()
    {
        var skinsList = new List<StoreItem>()
        {
            new StoreItem() { Id = 1, Name = "Blue Skin", ButtonName = "Buy  Button 3", Cost = 100},
            new StoreItem() { Id = 2, Name = "Red Skin", ButtonName = "Buy  Button 3 (1)", Cost = 100},
            new StoreItem() { Id = 3, Name = "Green Skin", ButtonName = "Buy  Button 3 (2)", Cost = 100},
        };

        var hatsList = new List<StoreItem>()
        {
            new StoreItem() { Id = 1, Name = "Witch Hat", ButtonName = "Buy  Button 3", Cost = 100},
            new StoreItem() { Id = 2, Name = "Top Hat", ButtonName = "Buy  Button 3 (1)", Cost = 100},
            new StoreItem() { Id = 3, Name = "Third Hat", ButtonName = "Buy  Button 3 (2)", Cost = 100},
        };

        var gunsList = new List<StoreItem>()
        {
            new StoreItem() { Id = 1, Name = "Ray Gun", ButtonName = "Buy  Button 3", Cost = 100},
            new StoreItem() { Id = 2, Name = "Water Gun", ButtonName = "Buy  Button 3 (1)", Cost = 100},
            new StoreItem() { Id = 3, Name = "Bubble Gun", ButtonName = "Buy  Button 3 (2)", Cost = 100},
        };

        var currencyList = new List<CurrencyBundle>()
        {
            new CurrencyBundle() { Id = 1, Name = "Bundle1", ButtonName = "Buy  Button 3", Cost = 1.99f},
            new CurrencyBundle() { Id = 2, Name = "Bundle2", ButtonName = "Buy  Button 3 (1)", Cost = 5.99f},
            new CurrencyBundle() { Id = 3, Name = "Bundle3", ButtonName = "Buy  Button 3 (2)", Cost = 10.99f},
        };

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
