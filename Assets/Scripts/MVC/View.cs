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
            _enemyNumText.text = "���������� " + Model.Instance.EnemyNum.ToString();
        };
        Model.Instance.DestroyEnemy = () =>
        {
            _diedEnemyNumText.text = "���������� " + Model.Instance.DiedEnemyNum.ToString();
        };
    }
}