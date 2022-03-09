using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorManager : MonoBehaviour
{
    //選択カーソルステータス
    private enum status
    {
        SelectOne = 0,
        SelectTwo
    }
    //カーソル1を宣言
    private GameObject cursor1;
    //カーソル2を宣言
    private GameObject cursor2;
    private status state;
    void Start()
    {
        //初期選択カーソルを1に初期化
        state = status.SelectOne;
        //カーソル1を探す
        cursor1 = GameObject.Find("cursorPrefab");
        //カーソル2を探す
        cursor2 = GameObject.Find("cursorPrefab2");
        //カーソル1を選択可能に初期化
        cursor1.GetComponent<cursorController>().state = cursorController.status.select;
        //カーソル2を選択前に初期化
        cursor2.GetComponent<cursorController>().state = cursorController.status.preSelect;
    }

    void Update()
    {
        
    }
}
