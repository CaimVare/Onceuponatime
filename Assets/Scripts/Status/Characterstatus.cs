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
    protected string characterName { get; set; } = "";
    //�@�ŏ�Ԃ��ǂ���
    [SerializeField]
    private bool isPoisonState = false;
    //�@���x��
    [SerializeField]
    protected int level { get; set; } = 1;
    //�@�ő�̗�
    [SerializeField]
    protected int maxHp = 100;
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
    protected int agility { get; set; } = 5;
    //�@��
    [SerializeField]
    protected int power { get; set; } = 10;
    //�@�d��
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
