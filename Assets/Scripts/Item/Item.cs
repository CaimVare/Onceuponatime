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
        HPRecovery,//HP��
        MPRecovery,//MP��
        PoisonRecovery,//�ŉ���
        WeaponAll,//����
        ArmorAll,//�h��
        Valuable,//�M�d�i
    }

    // �A�C�e���̎��
    [SerializeField]
    private Type itemType = Type.HPRecovery;
    //�A�C�e��������
    [SerializeField]
    private string kanjiName = "";
    //�A�C�e��������
    [SerializeField]
    private string hiraganaName = "";
    //�A�C�e�����
    [SerializeField]
    private string information = "";
    //�A�C�e���̃p�����[�^
    [SerializeField]
    private int amount = 0;

    //�A�C�e�����
    public Type GetItemType()
    {
        return itemType;
    }
    //�A�C�e������Ԃ�
    public string GetKanjiName()
    {
        return kanjiName;
    }
    //�A�C�e����������Ԃ�
    public string GethiraganaName()
    {
        return hiraganaName;
    }
    //�A�C�e������Ԃ�
    public string GetInfomation()
    {
        return information;
    }
    //�A�C�e������
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
