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
    protected string characterName { get; set; } = "";
    //　毒状態かどうか
    [SerializeField]
    private bool isPoisonState = false;
    //　レベル
    [SerializeField]
    protected int level { get; set; } = 1;
    //　最大体力
    [SerializeField]
    protected int maxHp = 100;
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
    protected int agility { get; set; } = 5;
    //　力
    [SerializeField]
    protected int power { get; set; } = 10;
    //　硬さ
    [SerializeField]
    protected int defense { get; set; } = 10;

    public void SetPoisonState(bool poisonFlog)
    {
        isPoisonState = poisonFlog;
    }

    public bool IsPoisonState()
    {
        return isPoisonState;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
