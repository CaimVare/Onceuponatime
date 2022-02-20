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
    //�l���o���l
    [SerializeField]
    protected int earnedExp { get; set; } = 0;
    //�������Ă��镐��
    [SerializeField]
    protected Item equipWeapon { get; set; } = null;
    //�������Ă���h��
    [SerializeField]
    protected Item equipArmor { get; set; } = null;
    //�A�C�e���̌��Ƃ܂Ƃ߂�����
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

    //�A�C�e�����o�^���ꂽ���Ԃ�itemDictionary��Ԃ�
    public ItemDictionary GetItemDictionary()
    {
        return itemDictionary;
    }
    //�������̖��O�Ń\�[�g����ItemDictionary��Ԃ�
    public IOrderedEnumerable<KeyValuePair<Item, int>> GetSortItemDictionary()
    {
        return itemDictionary.OrderBy(Item => Item.Key.GethiraganaName());
    }
    public int SetItemNum(Item tempItem, int num)
    {
        return itemDictionary[tempItem] = num;
    }
    //�A�C�e���̐���Ԃ�
    public int GetItemNum(Item item)
    {
        return itemDictionary[item];
    }
}

