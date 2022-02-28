using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cursorController : MonoBehaviour
{
    GameObject cursorPrefab;//�J�[�\���錾
    public GameObject[] Targets { get; private set; }//�J�[�\���ړ��p
    public int CurrentPos { get; private set; }//�J�[�\���ړ��p
    public GameObject[] CS { get; private set; }//�L�����I��p
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
        this.cursorPrefab = GameObject.Find("cursorPrefab");
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
                float cursorPos = this.cursorPrefab.transform.position.y;
                Debug.Log(cursorPos);

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
                //�I���㔼��������
                this.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.5f);
                //Rigidbody���擾
                var rb = GetComponent<Rigidbody>();
                //�ړ����Ȃ�����iFreezePosition���I���ɂ���
                //rb.constraints = RigidbodyConstraints.FreezePosition;
                //�G���^�[�t���O��1�𑫂�
                ent += 1;
                //�}�l�[�W���[�ɒl��Ԃ�
                //�J�[�\��2�Ɉڍs
            }
        }
        //�I������
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ent = 0;
            //���߂�߂�
            this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 1);
        }
    }
    
    
        
}
