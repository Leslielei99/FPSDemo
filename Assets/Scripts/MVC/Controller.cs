using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private static Controller instance;
    public static Controller Instance() { return instance; }
    private void Awake()
    {
        instance = this;
        Model.Instance.EnemyNum = 0;
        Model.Instance.DiedEnemyNum = 0;
    }
    public Controller()
    {
        instance = this;
    }
    public void DestoryEnemy()
    {
        Model.Instance.DiedEnemyNum++;
        Model.Instance.EnemyNum--;
    }
    public void CreatEnemy()
    {
        Model.Instance.EnemyNum++;
    }
}
