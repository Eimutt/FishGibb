using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory
{
    private Dictionary<int, int> inventory;

    public Inventory()
    {
        inventory = new Dictionary<int, int>();
    }

    public void UpdateItem(int itemId, int quantity)
    {
        if (inventory.ContainsKey(itemId))
        {
            inventory[itemId] += quantity;
        } else
        {
            inventory.Add(itemId, quantity);
        }
    }

    public int GetItemQuantity(int itemId)
    {
        return inventory[itemId];
    }
}
public class InventroyManager : MonoBehaviour
{
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateItemWrapper(int itemId, int quantity)
    {
        inventory.UpdateItem(itemId, quantity);
        //UI shit
        GameObject itemObj = gameObject.transform.Find("Item" + itemId.ToString()).gameObject;
        itemObj.transform.Find("Text").GetComponent<Text>().text = inventory.GetItemQuantity(itemId).ToString();
    }
}
