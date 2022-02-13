using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//�A�g���r���[�g�����t���邱�ƂŒ��񉻁i�f�[�^�]���j���\�ȃN���X�ɂ���
[Serializable]
public abstract class CharacterStatus : ScriptableObject
{
    //�@�L������
    [SerializeField]
    private string characterName = "";
    //�@�ŏ�Ԃ��ǂ���
    [SerializeField]
    private bool isPoisonState = false;
    //�@���x��
    [SerializeField]
    private int level = 1;
    //�@�ő�̗�
    [SerializeField]
    private int maxHp = 100;
    //�@�̗�
    [SerializeField]
    private int hp = 100;
    //�@�ő�C��
    [SerializeField]
    private int maxMp = 100;
    //�@�C��
    [SerializeField]
    private int mp = 100;
    //�@�f����
    [SerializeField]
    private int agility = 5;
    //�@��
    [SerializeField]
    private int power = 10;
    //�@�d��
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
        //Mathf.Min�ŃL�����̍ŏ�HP���擾���AMathf.Max�ōő�HP���擾
        this.hp = Mathf.Max(0, Mathf.Min(GetMaxHp(), hp));//������0�����邱�Ƃ�0��菬�����Ȃ�Ȃ��悤�ɂ���
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
        //Mathf.Min�ŃL�����̍ŏ�MP���擾���AMathf.Max�ōő�MP���擾
        this.mp = Mathf.Max(0, Mathf.Min(GetMaxMp(), mp));//������0�����邱�Ƃ�0��菬�����Ȃ�Ȃ��悤�ɂ���
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
