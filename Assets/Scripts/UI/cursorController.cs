using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cursorController : MonoBehaviour
{
    public GameObject[] Targets { get; private set; }
    public int CurrentPos { get; private set; }

    GameObject EnterGameObject;
    private void Start()
    {
        //�I���L������������
        EnterGameObject = null;
        //�L�����I��p�̋�I�u�W�F�N�g�z��
        string[] name = { "samuraicursor", "ninjacursor", "mikocursor", "onmyoujicursor" };
        Targets = new GameObject[name.Length];
        for (int i = 0; i < name.Length; i++)
        {
            Targets[i] = GameObject.Find(name[i]);
        }
        transform.position = Targets[CurrentPos].transform.position;
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

        //Enter�ŃL�����I��
        if (Input.GetKey(KeyCode.Return))
        {
            
            
            
        }
    }
}
