using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class View : MonoBehaviour
{
    private Text _enemyNumText;
    private Text _diedEnemyNumText;

    private void Awake()
    {
        _enemyNumText = transform.Find("EnemyNum").GetComponent<Text>();
        _diedEnemyNumText = transform.Find("DiedEnemy").GetComponent<Text>();
        BindFun();
    }

    private void BindFun()
    {
        Model.Instance.CreatEnemy = () =>
        {
            _enemyNumText.text = "敌人数量： " + Model.Instance.EnemyNum.ToString();
        };
        Model.Instance.DestroyEnemy = () =>
        {
            _diedEnemyNumText.text = "消灭数量： " + Model.Instance.DiedEnemyNum.ToString();
        };
    }
}
