using UnityEngine.Events;

public class Model
{
    private static Model instance;

    public static Model Instance
    {
        get
        {
            if (instance == null)
                instance = new Model();
            return instance;
        }
    }

    private int enemyNum;
    private int diedEnemyNum;

    public UnityAction CreatEnemy;
    public UnityAction DestroyEnemy;

    public int EnemyNum
    {
        get { return enemyNum; }
        set { if (CreatEnemy != null) CreatEnemy(); enemyNum = value; }
    }

    public int DiedEnemyNum
    {
        get { return diedEnemyNum; }
        set { if (DestroyEnemy != null) DestroyEnemy(); diedEnemyNum = value; }
    }
}