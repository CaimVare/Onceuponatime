using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cursorController : MonoBehaviour
{
    GameObject cursorPrefab;//�J�[�\��1�錾
    public GameObject[] Targets { get; private set; }//�J�[�\���ړ��p
    public int CurrentPos { get; private set; }//�J�[�\���ړ��p
    int select;//�G���^�[�t���O�p

    public void Start()
    {
        //�J�[�\���ړ��p�̋�I�u�W�F�N�g�z��
        string[] name = { "samuraicursor", "ninjacursor", "mikocursor", "onmyoujicursor", "Completioncursor" };
        Targets = new GameObject[name.Length];
        for (int i = 0; i < name.Length; i++)
        {
            Targets[i] = GameObject.Find(name[i]);
        }
        transform.position = Targets[CurrentPos].transform.position;
        //�J�[�\��1��T��
        this.cursorPrefab = GameObject.Find("cursorPrefab");
        //�G���^�[�t���O
        select = 0;
    }
    public void Update()
    {
        if (select == 0)
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
                select += 1;
                //BattleManager�ɒl��Ԃ�
                //�J�[�\��2�Ɉڍs
            }
        }
        //�I������
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
             select = 0;
             //���߂�߂�
             this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            //BattleManager�ɒl��Ԃ�
            }
    }
    
    
        
}
