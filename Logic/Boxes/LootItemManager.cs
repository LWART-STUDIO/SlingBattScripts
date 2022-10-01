using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Custom.Logic.Boxes
{
	public static class LootItemManager
	{
		/*
	 *	This class runs when the game is played and stores the item info 
	 *	so we can access it when opening a lootbox	
	 */

		public static List<Item> allItems = new List<Item>();
		public const string ALL_ITEMS_DATA_PATH = "DataFiles/ItemData";
		public static List<Item> CardsItems = new List<Item>(); 
		public const string CARDS_DATA_PATH = "DataFiles/CardsData";//This is the list that contains all items in the game
	
		//Run on start (Scene independent)
		[RuntimeInitializeOnLoadMethod]
		static void InitClass() {
			Debug.Log("ItemManager initialized");
			CreateItems(); //Parses data and creates all items
		}

		private static void CreateItems() {
			//Load in the loot table csv file (saved in Resources/DataFiles/ItemList)
			InitItems(allItems,ALL_ITEMS_DATA_PATH);
			InitItems(CardsItems,CARDS_DATA_PATH);
		}

		private static void InitItems(List<Item> list, string DataPath)
		{
			var loadedFile = Resources.Load<TextAsset>(DataPath);
		
			//Split the csv file per line and put into a list 
			var splitData = loadedFile.text.Split('\n').ToList();
		
			//Create the item classes
			foreach (var line in splitData) { //Loop through the split up data
				var itemInfo = line.Split(','); //Then split each line by comma

				if (line.Equals(""))
				{
					continue;
				} 
				//We then create the new item from our item class template (our template should be formatted as 0-ItemName, 1-ItemType, 2-ItemValue, 3-ItemRarity, 4-SpokeWeight)
				var newItem = new Item(itemInfo[0].TrimEnd(), Int32.Parse(itemInfo[2]), itemInfo[1].TrimEnd(), itemInfo[3].TrimEnd(), Int32.Parse(itemInfo[4]));
			
				list.Add(newItem); //Add the item we created to the list of all items
			}
		}

		public static Item GetItem(ItemListType type)
		{
			//A method to retrieve a new random item
			switch (type)
			{
				case ItemListType.AllItems:
					return GetItemInAll();
				case ItemListType.Cards:
					return GetItemInCards();
			}

			return null;
		}

		private static Item GetItemInAll()
		{
			var totalWeights = 0; //Initialize a variable to store the spoke weight of all of our items
			foreach (var item in allItems) { //Loop through all the items and add their spoke weights together
				totalWeights += item.dropWeight;
			}

			var randomWeightValue= Random.Range(0, totalWeights); //We then pick a random number between 0 and the total spoke weight
			Item itemToReturn = null; //Create a variable to store the item we want to return
		
			for (int i = 0; i < allItems.Count; i++) { //Loop through all of the items again
				/*This next part works like so; You check to see if our random number is lower than the spoke weight
			 * of the item we are looking at, and if it is, then that is the item we return, otherwise we remove
			 * the spoke weight of the item from the random value and move onto the next item in the list.
			 */
				if (randomWeightValue <= allItems[i].dropWeight) {
					itemToReturn = allItems[i];
					break;
				} else {
					randomWeightValue -= allItems[i].dropWeight;
				}
			}

			itemToReturn.owned = true; //We tell the item that it is now owned
			return itemToReturn;
		}
		private static Item GetItemInCards()
		{
			var totalWeights = 0; //Initialize a variable to store the spoke weight of all of our items
			foreach (var item in CardsItems) { //Loop through all the items and add their spoke weights together
				totalWeights += item.dropWeight;
			}

			var randomWeightValue= Random.Range(0, totalWeights); //We then pick a random number between 0 and the total spoke weight
			Item itemToReturn = null; //Create a variable to store the item we want to return
		
			for (int i = 0; i < CardsItems.Count; i++) { //Loop through all of the items again
				/*This next part works like so; You check to see if our random number is lower than the spoke weight
			 * of the item we are looking at, and if it is, then that is the item we return, otherwise we remove
			 * the spoke weight of the item from the random value and move onto the next item in the list.
			 */
				if (randomWeightValue <= CardsItems[i].dropWeight) {
					itemToReturn = CardsItems[i];
					break;
				} else {
					randomWeightValue -= CardsItems[i].dropWeight;
				}
			}

			itemToReturn.owned = true; //We tell the item that it is now owned
			return itemToReturn;
		}
			
	
	}

	public class Item
	{
		//Items info
		public string name;
		public int value;
		public string type;
		public string rarity;
		public int dropWeight;
		public Sprite itemSprite;
	
		public bool owned;

		public Item(string itemName, int itemValue, string itemType, string itemRarity, int weight) {
			name = itemName;
			value = itemValue;
			type = itemType;
			rarity = itemRarity;
			dropWeight = weight;
			owned = false;

			itemSprite = Resources.Load<Sprite>("ItemIcons/" + itemName); //Get basic sprite from resources file (Replace itemType with itemName if we had individual sprites)
		}
	}

	public enum ItemListType
	{
		AllItems=0,
		Cards=2,
	}
}