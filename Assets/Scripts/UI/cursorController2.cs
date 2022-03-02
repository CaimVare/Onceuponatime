using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorController2 : MonoBehaviour
{
    GameObject cursorPrefab2;//カーソル宣言
    public GameObject[] Targets { get; private set; }//カーソル移動用
    public int CurrentPos { get; private set; }//カーソル移動用
    int ent;//エンターフラグ用
    private void Start()
    {
        //カーソル移動用の空オブジェクト配列
        string[] name = { "samuraicursor", "ninjacursor", "mikocursor", "onmyoujicursor" };
        Targets = new GameObject[name.Length];
        for (int i = 0; i < name.Length; i++)
        {
            Targets[i] = GameObject.Find(name[i]);
        }
        transform.position = Targets[CurrentPos].transform.position;
        //カーソル探す
        this.cursorPrefab2 = GameObject.Find("cursorPrefab2");
        //エンターフラグ
        ent = 0;
    }
    void Update()
    {
        if (ent == 0)
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
                float cursorPos = this.cursorPrefab2.transform.position.y;
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
                ent += 1;
                //BattleManagerに値を返す
                //カーソル2に移行
            }
        }
        //選択解除
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ent = 0;
            //透過を戻す
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            //BattleManagerに値を返す
        }
    }
}
