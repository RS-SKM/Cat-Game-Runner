using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoreItemDatabase : MonoBehaviour
{
    [Serializable] //Shows the class in the inspector
    public class StoreItem
    {
        public int Id;
        public string Name;
        public GameObject Button;
        public int Cost;
    }

    [Serializable]
    public class CurrencyBundle
    {
        public int Id;
        public string Name;
        public GameObject Button;
        public float Cost;
    }


        public List<StoreItem> skinsList = new List<StoreItem>(); //Lists can be added to through the inspector (because of "public List<StoreItem>")

        public List<StoreItem> hatsList = new List<StoreItem>();

        public List<StoreItem> gunsList = new List<StoreItem>();

        public List<CurrencyBundle> currencyList = new List<CurrencyBundle>(); 


        // Start is called before the first frame update
            void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
