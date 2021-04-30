using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public LootTable loottable;
    // Start is called before the first frame update

    public void DropStuff()
    {
        foreach (Loot loot in loottable.LootDrops)
        {
            var rand = Random.Range(0f, 1f);
            if(loot.dropRate >= rand)
            {
                Instantiate(loot.item, this.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity, GameObject.Find("Loot").transform);
            }
        }
    }
}
