using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cursorController : MonoBehaviour
{
    GameObject cursorPrefab;//カーソル1宣言
    public GameObject[] Targets { get; private set; }//カーソル移動用
    public int CurrentPos { get; private set; }//カーソル移動用
    int select;//エンターフラグ用

    public void Start()
    {
        //カーソル移動用の空オブジェクト配列
        string[] name = { "samuraicursor", "ninjacursor", "mikocursor", "onmyoujicursor", "Completioncursor" };
        Targets = new GameObject[name.Length];
        for (int i = 0; i < name.Length; i++)
        {
            Targets[i] = GameObject.Find(name[i]);
        }
        transform.position = Targets[CurrentPos].transform.position;
        //カーソル1を探す
        this.cursorPrefab = GameObject.Find("cursorPrefab");
        //エンターフラグ
        select = 0;
    }
    public void Update()
    {
        if (select == 0)
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
                Debug.Log(cursorPos);
                //半透明にする
                this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
                GameObject selected = null;//キャラ選択を初期化
                //配列からｙ軸が同じだったオブジェクトを返す
                for (int i = 0; i < Targets.Length; i++)
                {
                    if (cursorPos == Targets[i].transform.position.y)
                    {
                        selected = Targets[i];
                        Debug.Log(Targets[i]);
                    }
                }
                //エンターフラグに1を足す
                select += 1;
                //BattleManagerに値を返す
                //カーソル2に移行
            }
        }
        //選択解除
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
             select = 0;
             //透過を戻す
             this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            //BattleManagerに値を返す
            }
    }
    
    
        
}
