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
    GameObject cursorPrefab;//カーソル1宣言
    GameObject cursorPrefab2;//カーソル2宣言
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
        this.cursorPrefab = GameObject.Find("cursorPrefab");
        //カーソル2を探す
        this.cursorPrefab2 = GameObject.Find("cursorPrefab2");
    }
    public void Update()
    {
        switch (state)
        {
            case status.preSelect://選択前処理
                {
                    //透明にする
                    this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                    //選択可能へ
                    if (Input.GetKeyDown(KeyCode.Return))
                        state = status.select;
                    break;
                 }

            case status.select://選択可能処理
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
                        //Debug.Log(cursorPos);
                        //半透明にする
                        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
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
                        //BattleManagerに値を返す
                    }
                    break;
                }
            case status.DoneWait://選択後待機処理
                {
                    //選択解除 左矢印を押したとき
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        //選択可能に戻す
                        state = status.select;
                        //透過を戻す
                        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
                        //BattleManagerに値を返す
                    }
                    //選択終了へ
                    if(Input.GetKeyDown(KeyCode.Return))
                    {
                        //エンターを押したとき
                        state = status.Done;
                        //透明化
                        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                    }
                    break;
                }
            case status.Done://選択終了
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        //選択後待機に戻す
                        state = status.DoneWait;
                        //透過を戻す
                        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
                    }
                    break;
                }
         
        }
        
    }
    
    
        
}
