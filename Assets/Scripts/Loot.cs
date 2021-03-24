using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GenericLootDrop<T>
{
    public T item;
    public float dropRate;
}

public abstract class GenericLootTable<T, U> where T : GenericLootDrop<U>
{
    [SerializeField]
    public List<T> LootDrops;
}

[System.Serializable]
public class Loot : GenericLootDrop<GameObject> { }

[System.Serializable]
public class LootTable : GenericLootTable<Loot, GameObject> { }
