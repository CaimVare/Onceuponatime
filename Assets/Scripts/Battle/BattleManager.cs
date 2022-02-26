using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //　現在戦闘に参加している全キャラクター
    private List<GameObject> allCharacterInBattleList = new List<GameObject>();
    //　現在戦闘に参加している味方キャラクター
    private List<GameObject> allyCharacterInBattleList = new List<GameObject>();
    //　現在戦闘に参加している敵キャラクター
    private List<GameObject> enemyCharacterInBattleList = new List<GameObject>();
 
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
