using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorManager : MonoBehaviour
{
    //選択カーソルステータス
    private enum CursorStatus
    {
        SelectOne = 0,
        SelectTwo
    }
    //カーソル1を宣言
    private GameObject cursor1;
    //カーソル2を宣言
    private GameObject cursor2;
    private CursorStatus state;
    void Start()
    {
        //初期選択カーソルを1に初期化
        state = CursorStatus.SelectOne;
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
        switch(state)
        {
            case CursorStatus.SelectOne://カーソル1選択時
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
