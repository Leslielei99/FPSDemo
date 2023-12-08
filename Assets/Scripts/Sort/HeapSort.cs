using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class HeapSort : MonoBehaviour
{
    public Button InitButton;
    public Button SortButton;
    public InputField AddField;
    public Button AddButton;
    public Button CleanButton;
    public Text ConText;

    // 生成随机数
    private int[] randomNumbers = new int[1000000];

    //目标数组
    private int[] disArray = new int[10];

    //存入队列中
    private Queue<int> queue = new Queue<int>();

    private void Start()
    {
        InitButton.onClick.AddListener(InitNum);
        SortButton.onClick.AddListener(SortNum);
        AddButton.onClick.AddListener(AddNum);
        CleanButton.onClick.AddListener(CleanAll);
    }

    /// <summary>
    /// 清除
    /// </summary>
    public void CleanAll()
    {
        randomNumbers = null;
        disArray = null;
        queue.Clear();
        AddField.text = string.Empty;
        ConText.text = string.Empty;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void InitNum()
    {
        randomNumbers = new int[1000000];
        StringBuilder sb = new StringBuilder();
        disArray = new int[10];
        ConText.text = "";
        for (int i = 0; i < 1000000; i++)
        {
            randomNumbers[i] = UnityEngine.Random.Range(0, 1000001);
            sb.Append(randomNumbers[i] + " ");
        }
        ConText.text = sb.ToString();
    }

    /// <summary>
    /// 初始排序
    /// </summary>
    public void SortNum()
    {
        Array.Copy(randomNumbers, disArray, 10);
        //将前十个排序
        Heap_Sort(ref disArray, disArray.Length);

        for (int i = 0; i < 10; i++)
        {
            queue.Enqueue(disArray[i]);
        }
        //遍历后99990个数据，如果大于堆顶，则入队列，同时堆顶数据出队列
        for (int i = 10; i < randomNumbers.Length; i++)
        {
            if (randomNumbers[i] > queue.Peek())
            {
                queue.Dequeue();
                queue.Enqueue(randomNumbers[i]);
            }
        }
        disArray = queue.ToArray();

        LastSort();
    }

    /// <summary>
    /// 最后排序
    /// </summary>
    public void LastSort()
    {
        //最后在排序
        Heap_Sort(ref disArray, disArray.Length);
        queue.Clear();
        ConText.text = "";
        for (int i = 0; i < disArray.Length; i++)
        {
            queue.Enqueue(disArray[i]);
            ConText.text = ConText.text + disArray[i].ToString() + "\n";
        }
    }

    /// <summary>
    /// 添加数据
    /// </summary>
    public void AddNum()
    {
        int tmp = Convert.ToInt32(AddField.text);
        if (tmp > queue.Peek())
        {
            queue.Dequeue();
            queue.Enqueue(tmp);
        }
        else
        {
            return;
        }
        disArray = queue.ToArray();
        LastSort();
    }

    /// <summary>
    /// 维护堆的性质
    /// </summary>
    /// <param name="arr">存储堆的数组</param>
    /// <param name="n">数组长度</param>
    /// <param name="i">待维护节点的下标</param>
    private static void Heapify(ref int[] arr, int n, int i)
    {
        int largest = i;
        int lson = i * 2 + 1;
        int rson = i * 2 + 2;
        if (lson < n && arr[largest] < arr[lson])
        {
            largest = lson;
        }
        if (rson < n && arr[largest] < arr[rson])
        {
            largest = rson;
        }
        if (largest != i)
        {
            Swap(ref arr[largest], ref arr[i]);
            Heapify(ref arr, n, largest);
        }
    }

    public static void Heap_Sort(ref int[] arr, int n)
    {
        int i;
        for (i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(ref arr, n, i);
        }
        for (i = n - 1; i > 0; i--)
        {
            Swap(ref arr[i], ref arr[0]);
            Heapify(ref arr, i, 0);
        }
    }

    private static void Swap(ref int a, ref int b)
    {
        int tmp = a;
        a = b; b = tmp;
    }
}