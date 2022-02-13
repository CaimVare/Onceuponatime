using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//アトリビュートを取り付けることで直列化（データ転送可）が可能なクラスにする
[Serializable]
public abstract class CharacterStatus : ScriptableObject
{
    //　キャラ名
    [SerializeField]
    private string characterName = "";
    //　毒状態かどうか
    [SerializeField]
    private bool isPoisonState = false;
    //　レベル
    [SerializeField]
    private int level = 1;
    //　最大体力
    [SerializeField]
    private int maxHp = 100;
    //　体力
    [SerializeField]
    private int hp = 100;
    //　最大気力
    [SerializeField]
    private int maxMp = 100;
    //　気力
    [SerializeField]
    private int mp = 100;
    //　素早さ
    [SerializeField]
    private int agility = 5;
    //　力
    [SerializeField]
    private int power = 10;
    //　硬さ
    [SerializeField]
    private int defense = 10;

    public void SetCharacterName(string characterName)
    {
        this.characterName = characterName;
    }

    public string GetCharacterName()
    {
        return characterName;
    }

    public void SetPoisonState(bool poisonFlog)
    {
        isPoisonState = poisonFlog;
    }

    public bool IsPoisonState()
    {
        return isPoisonState;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetMaxHp(int hp)
    {
        this.maxHp = hp;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    public void SetHp(int hp)
    {
        //Mathf.Minでキャラの最小HPを取得し、Mathf.Maxで最大HPを取得
        this.hp = Mathf.Max(0, Mathf.Min(GetMaxHp(), hp));//引数で0を入れることで0より小さくならないようにする
    }

    public int GetHp()
    {
        return hp;
    }

    public void SetMaxMp(int mp)
    {
        this.maxMp = mp;
    }

    public int GetMaxMp()
    {
        return maxMp;
    }

    public void SetMp(int mp)
    {
        //Mathf.Minでキャラの最小MPを取得し、Mathf.Maxで最大MPを取得
        this.mp = Mathf.Max(0, Mathf.Min(GetMaxMp(), mp));//引数で0を入れることで0より小さくならないようにする
    }

    public int GetMp()
    {
        return mp;
    }

    public void SetAgility(int agility)
    {
        this.agility = agility;
    }

    public int GetAgilety()
    {
        return agility;
    }

    public void SetPower(int power)
    {
        this.power = power;
    }

    public int GetPower()
    {
        return power;
    }

    public void SetDefence(int defence)
    {
        this.defense = defence;
    }

    public int GetDefence(int defence)
    {
        return defence;
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
