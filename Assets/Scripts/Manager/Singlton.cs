using System;

public class Singlton<T> where T : class//泛型
{
    private static T _singlton;

    public static T Instance
    {
        get
        {
            if (_singlton == null)
            {
                //_singlton = new T();
                //如果这样写,那么该类型T必有一个Public的构造函数
                //_singleton = new T(O;
                //通过反射的方式，去实例化一个对象出来
                //这样，派生的单例类中必须要有一个私有的无参的构造
                _singlton = (T)Activator.CreateInstance(typeof(T), nonPublic: true);
            }
            return _singlton;
        }
    }
}