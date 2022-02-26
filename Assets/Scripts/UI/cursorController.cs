using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cursorController : MonoBehaviour
{
    GameObject cursorPrefab;
    GameObject samuraiPrefab;
    GameObject ninjaPrefab;
    GameObject mikoPrefab;
    GameObject onmyouzPrefabi;
    GameObject Character;
    public GameObject[] Targets { get; private set; }//カーソル移動用
    public int CurrentPos { get; private set; }//カーソル移動用
    public GameObject[] CS { get; private set; }//キャラ選択用
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
        this.cursorPrefab = GameObject.Find("cursorPrefab");
        //キャラ選択用配列
        string[] Character = { "samuraiPrefab", "ninjaPrefab", "mikoPrefab", "onmyouzPrefabi" };
        CS = new GameObject[Character.Length];
        for (int c = 0; c < Character.Length; c++)
        {
            CS[c] = GameObject.Find(Character[c]);
        }
        this.Character = GameObject.Find(null);
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
        

        //Enterを押したとき
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //カーソルの場所
            float cursorPos = this.cursorPrefab.transform.position.y;
            Debug.Log("キャラ選択したい！");
            Debug.Log(cursorPos);
            //当たり判定
            float samuraiPos = this.samuraiPrefab.transform.position.y;
        }
    }
}
