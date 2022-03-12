using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorManager : MonoBehaviour
{
    //�I���J�[�\���X�e�[�^�X
    private enum CursorStatus
    {
        SelectOne = 0,
        SelectTwo
    }
    //�J�[�\��1��錾
    private GameObject cursor1;
    //�J�[�\��2��錾
    private GameObject cursor2;
    private CursorStatus state;
    void Start()
    {
        //�����I���J�[�\����1�ɏ�����
        state = CursorStatus.SelectOne;
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
        switch(state)
        {
            case CursorStatus.SelectOne://�J�[�\��1�I����
                {
                    if (cursor1.GetComponent<cursorController>().selected != null)
                    {
                        state = CursorStatus.SelectTwo;
                        cursor2.GetComponent<cursorController>().state = cursorController.status.select;
                    }
                    break;
                }
            case CursorStatus.SelectTwo:
                {
                    if(cursor2.GetComponent<cursorController>().selected != null)
                    {

                    }
                    break;
                }

        }
    }
}
