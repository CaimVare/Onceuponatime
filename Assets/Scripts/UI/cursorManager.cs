using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorManager : MonoBehaviour
{
    //�I���J�[�\���X�e�[�^�X
    private enum status
    {
        SelectOne = 0,
        SelectTwo
    }
    //�J�[�\��1��錾
    private GameObject cursor1;
    //�J�[�\��2��錾
    private GameObject cursor2;
    private status state;
    void Start()
    {
        //�����I���J�[�\����1�ɏ�����
        state = status.SelectOne;
        //�J�[�\��1��T��
        cursor1 = GameObject.Find("cursorPrefab");
        //�J�[�\��2��T��
        cursor2 = GameObject.Find("cursorPrefab2");
        //�J�[�\��1��I���\�ɏ�����
        cursor1.GetComponent<cursorController>().state = cursorController.status.select;
        //�J�[�\��2��I��O�ɏ�����
        cursor2.GetComponent<cursorController>().state = cursorController.status.preSelect;
    }

    void Update()
    {
        
    }
}
