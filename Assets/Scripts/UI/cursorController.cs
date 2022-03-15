using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cursorController : MonoBehaviour
{
    public enum status
    {
        preSelect = 0,//選択前
        select,//選択可能
        DoneWait,//選択後待機
        Done,//選択終了
        Completionc//完了
    }
    GameObject cursorPrefab;//カーソル宣言
    public GameObject[] Targets { get; private set; }//カーソル移動用
    public int CurrentPos { get; private set; }//カーソル移動用
    public status state;//カーソルステータス管理
    public GameObject selected;//キャラ選択用

    private void Start()
    {
        //カーソル移動用の空オブジェクト配列
        string[] name = { "samuraicursor", "ninjacursor", "mikocursor", "onmyoujicursor"};
        Targets = new GameObject[name.Length];
        for (int i = 0; i < name.Length; i++)
        {
            Targets[i] = GameObject.Find(name[i]);
        }
        transform.position = Targets[CurrentPos].transform.position;
        //カーソル1を探す
        cursorPrefab = gameObject;
    }
    public void Update()
    {
        switch (state)//ステータス毎のキー操作
        {
            case status.preSelect://選択前
                {

                    //選択可能へ
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        state = status.select;
                        ChangeState(status.select);
                    }
                    break;
                 }

            case status.select://選択可能
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

                    //Enterを押したとき
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //カーソルの場所
                        float cursorPos = this.cursorPrefab.transform.position.y;
                        GameObject selected = null;//キャラ選択を初期化
                        //配列からｙ軸が同じだったオブジェクトを返す
                        for (int i = 0; i < Targets.Length; i++)
                        {
                            if (cursorPos == Targets[i].transform.position.y)
                            {
                                selected = Targets[i];
                                Debug.Log(Targets[i] + "を選択した");
                            }
                        }
                        //選択後待機に移行
                        state = status.DoneWait;
                        ChangeState(status.DoneWait);
                    }
                    break;
                }
            case status.DoneWait://選択後待機
                {
                    //左矢印を押したとき
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        state = status.select;//選択可能へ
                    }
                    //選択終了へ エンターを押したとき
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        state = status.Done;//選択終了へ
                        ChangeState(status.Done);
                    }
                    break;
                }
            case status.Done://選択終了
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        //選択後待機に戻す
                        state = status.DoneWait;
                        ChangeState(status.DoneWait);

                    }
                    break;
                }
            case status.Completionc://完了
                {
                    break;

                }
        }          
    }
    public void ChangeState(status state)//ステータス毎の処理
    {
        switch(state)
        {
            case status.preSelect://選択待ち
                {
                    //透明
                    GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                    
                    break;
                }
            case status.select://選択中
                {
                    //透過ゼロ
                    GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
                    
                    break;
                }
            case status.DoneWait://選択待機中
                {
                    //半透明
                    GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
                    
                    break;
                }
            case status.Done://選択終了
                {
                    
                    
                    break;
                }
        }
    }
    
    
        
}
