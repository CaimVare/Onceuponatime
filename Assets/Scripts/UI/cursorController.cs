using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cursorController : MonoBehaviour
{
    public enum status
    {
        preSelect = 0,//�I��O
        select,//�I���\
        DoneWait,//�I����ҋ@
        Done,//�I���I��
        Completionc//����
    }
    GameObject cursorPrefab;//�J�[�\��1�錾
    GameObject cursorPrefab2;//�J�[�\��2�錾
    public GameObject[] Targets { get; private set; }//�J�[�\���ړ��p
    public int CurrentPos { get; private set; }//�J�[�\���ړ��p
    public status state;//�J�[�\���X�e�[�^�X�Ǘ�
    public GameObject selected;//�L�����I��p

    private void Start()
    {
        //�J�[�\���ړ��p�̋�I�u�W�F�N�g�z��
        string[] name = { "samuraicursor", "ninjacursor", "mikocursor", "onmyoujicursor"};
        Targets = new GameObject[name.Length];
        for (int i = 0; i < name.Length; i++)
        {
            Targets[i] = GameObject.Find(name[i]);
        }
        transform.position = Targets[CurrentPos].transform.position;
        //�J�[�\��1��T��
        this.cursorPrefab = GameObject.Find("cursorPrefab");
        //�J�[�\��2��T��
        this.cursorPrefab2 = GameObject.Find("cursorPrefab2");
    }
    public void Update()
    {
        switch (state)
        {
            case status.preSelect://�I��O����
                {
                    //�����ɂ���
                    this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                    //�I���\��
                    if (Input.GetKeyDown(KeyCode.Return))
                        state = status.select;
                    break;
                 }

            case status.select://�I���\����
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
                        //Debug.Log(cursorPos);
                        //�������ɂ���
                        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
                        GameObject selected = null;//�L�����I����������
                                                   //�z�񂩂炙���������������I�u�W�F�N�g��Ԃ�
                        for (int i = 0; i < Targets.Length; i++)
                        {
                            if (cursorPos == Targets[i].transform.position.y)
                            {
                                selected = Targets[i];
                                Debug.Log(Targets[i] + "��I������");
                            }
                        }
                        //�I����ҋ@�Ɉڍs
                        state = status.DoneWait;
                        //BattleManager�ɒl��Ԃ�
                    }
                    break;
                }
            case status.DoneWait://�I����ҋ@����
                {
                    //�I������ �������������Ƃ�
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        //�I���\�ɖ߂�
                        state = status.select;
                        //���߂�߂�
                        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
                        //BattleManager�ɒl��Ԃ�
                    }
                    //�I���I����
                    if(Input.GetKeyDown(KeyCode.Return))
                    {
                        //�G���^�[���������Ƃ�
                        state = status.Done;
                        //������
                        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                    }
                    break;
                }
            case status.Done://�I���I��
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        //�I����ҋ@�ɖ߂�
                        state = status.DoneWait;
                        //���߂�߂�
                        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
                    }
                    break;
                }
         
        }
        
    }
    
    
        
}
