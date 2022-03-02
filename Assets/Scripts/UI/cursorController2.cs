using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorController2 : MonoBehaviour
{
    GameObject cursorPrefab2;//�J�[�\���錾
    public GameObject[] Targets { get; private set; }//�J�[�\���ړ��p
    public int CurrentPos { get; private set; }//�J�[�\���ړ��p
    int ent;//�G���^�[�t���O�p
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
        this.cursorPrefab2 = GameObject.Find("cursorPrefab2");
        //�G���^�[�t���O
        ent = 0;
    }
    void Update()
    {
        if (ent == 0)
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
                float cursorPos = this.cursorPrefab2.transform.position.y;
                Debug.Log(cursorPos);
                //�������ɂ���
                this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
                GameObject selected = null;//�L�����I����������
                //�z�񂩂炙���������������I�u�W�F�N�g��Ԃ�
                for (int i = 0; i < Targets.Length; i++)
                {
                    if (cursorPos == Targets[i].transform.position.y)
                    {
                        selected = Targets[i];
                        Debug.Log(Targets[i]);
                    }
                }
                //�G���^�[�t���O��1�𑫂�
                ent += 1;
                //BattleManager�ɒl��Ԃ�
                //�J�[�\��2�Ɉڍs
            }
        }
        //�I������
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ent = 0;
            //���߂�߂�
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            //BattleManager�ɒl��Ԃ�
        }
    }
}