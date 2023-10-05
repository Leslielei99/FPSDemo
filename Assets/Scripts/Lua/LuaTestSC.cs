using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaTestSC : MonoBehaviour
{
    LuaEnv luaEnv = null;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString("require 'LuaTest'");
        Person p = luaEnv.Global.Get<Person>("person");
        print(p.name + "/" + p.age);
        p.name = "Liat";
        luaEnv.DoString("print(person.name)");
        luaEnv.Dispose();
    }
    class Person
    {
        public string name;
        public int age;
    }

}
