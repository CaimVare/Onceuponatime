using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]

public class Item : ScriptableObject
{
    public enum Type
    {
        HPRecovery,//HP回復
        MPRecovery,//MP回復
        PoisonRecovery,//毒解除
        WeaponAll,//武器
        ArmorAll,//防具
        Valuable,//貴重品
    }

    // アイテムの種類
    [SerializeField]
    private Type itemType = Type.HPRecovery;
    //アイテム漢字名
    [SerializeField]
    private string kanjiName = "";
    //アイテム平仮名
    [SerializeField]
    private string hiraganaName = "";
    //アイテム情報
    [SerializeField]
    private string information = "";
    //アイテムのパラメータ
    [SerializeField]
    private int amount = 0;

    //アイテム種類
    public Type GetItemType()
    {
        return itemType;
    }
    //アイテム名を返す
    public string GetKanjiName()
    {
        return kanjiName;
    }
    //アイテム平仮名を返す
    public string GethiraganaName()
    {
        return hiraganaName;
    }
    //アイテム情報を返す
    public string GetInfomation()
    {
        return information;
    }
    //アイテム強さ
    public int GetAmount()
    {
        return amount;
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
