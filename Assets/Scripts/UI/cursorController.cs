using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cursorController : MonoBehaviour
{
    GameObject cursorPrefab;
    GameObject samuraiPrefab;
    GameObject ninjaPrefab;
    GameObject mikoPrefab;
    GameObject onmyouzPrefabi;
    GameObject Character;
    public GameObject[] Targets { get; private set; }//�J�[�\���ړ��p
    public int CurrentPos { get; private set; }//�J�[�\���ړ��p
    public GameObject[] CS { get; private set; }//�L�����I��p
    private void Start()
    {
        //�J�[�\���ړ��p�̋�I�u�W�F�N�g�z��
        string[] name = { "samuraicursor", "ninjacursor", "mikocursor", "onmyoujicursor" };
        Targets = new GameObject[name.Length];
        for (int i = 0; i < name.Length; i++)
        {
            Targets[i] = GameObject.Find(name[i]);
        }
        transform.position = Targets[CurrentPos].transform.position;
        //�J�[�\���T��
        this.cursorPrefab = GameObject.Find("cursorPrefab");
        //�L�����I��p�z��
        string[] Character = { "samuraiPrefab", "ninjaPrefab", "mikoPrefab", "onmyouzPrefabi" };
        CS = new GameObject[Character.Length];
        for (int c = 0; c < Character.Length; c++)
        {
            CS[c] = GameObject.Find(Character[c]);
        }
        this.Character = GameObject.Find(null);
    }
    void Update()
    {
        //����Ŕz���1��Ɉړ�
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CurrentPos > 0) CurrentPos--;
        }
        //�����Ŕz���1���Ɉړ�
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CurrentPos < Targets.Length - 1) CurrentPos++;
        }
        transform.position = Targets[CurrentPos].transform.position;
        

        //Enter���������Ƃ�
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //�J�[�\���̏ꏊ
            float cursorPos = this.cursorPrefab.transform.position.y;
            Debug.Log("�L�����I���������I");
            Debug.Log(cursorPos);
            //�����蔻��
            float samuraiPos = this.samuraiPrefab.transform.position.y;
        }
    }
}
