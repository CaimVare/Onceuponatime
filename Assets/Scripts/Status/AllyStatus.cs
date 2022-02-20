using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "AllyStatus", menuName = "CreateAllyStatus")]

public class AllStatus : CharacterStatus
{
    //獲得経験値
    [SerializeField]
    protected int earnedExp { get; set; } = 0;
    //装備している武器
    [SerializeField]
    protected Item equipWeapon { get; set; } = null;
    //装備している防具
    [SerializeField]
    protected Item equipArmor { get; set; } = null;
    //アイテムの個数とまとめたもの
    [SerializeField]
    private ItemDictionary itemDictionary = null;

    public void CreateItemDictionary(ItemDictionary itemDictionary)
    {
        this.itemDictionary = itemDictionary;
    }

    public void SetItemDictionary(Item item, int num = 0)
    {
        itemDictionary.Add(item, num);
    }

    //アイテムが登録された順番のitemDictionaryを返す
    public ItemDictionary GetItemDictionary()
    {
        return itemDictionary;
    }
    //平仮名の名前でソートしたItemDictionaryを返す
    public IOrderedEnumerable<KeyValuePair<Item, int>> GetSortItemDictionary()
    {
        return itemDictionary.OrderBy(Item => Item.Key.GethiraganaName());
    }
    public int SetItemNum(Item tempItem, int num)
    {
        return itemDictionary[tempItem] = num;
    }
    //アイテムの数を返す
    public int GetItemNum(Item item)
    {
        return itemDictionary[item];
    }
}

