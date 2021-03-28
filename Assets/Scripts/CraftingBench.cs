using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBench : MonoBehaviour
{
    private GameObject craftingMenu;
    private bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        craftingMenu = GameObject.Find("CraftingMenu");
        craftingMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (menuOpen)
            {
                craftingMenu.SetActive(false);
                menuOpen = false;
                Time.timeScale = 0;
            }
            else
            {
                craftingMenu.SetActive(true);
                menuOpen = true;
                Time.timeScale = 1;
            }
        }
    }
}
