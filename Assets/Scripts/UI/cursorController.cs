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
        //選択キャラを初期化
        EnterGameObject = null;
        //キャラ選択用の空オブジェクト配列
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
        //上矢印で配列の1つ上に移動
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CurrentPos > 0) CurrentPos--;
        }
        //下矢印で配列の1つ下に移動
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CurrentPos < Targets.Length - 1) CurrentPos++;
        }
        transform.position = Targets[CurrentPos].transform.position;

        //Enterでキャラ選択
        if (Input.GetKey(KeyCode.Return))
        {
            
            
            
        }
    }
}
