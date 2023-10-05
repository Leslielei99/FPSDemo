using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scripts.Weapon;
public class Taxtmanager : MonoBehaviour
{
    Text text1;
    private Firearms firearms;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        text1 = GetComponent<Text>();
        //firearms = GameObject.FindGameObjectWithTag("Player").GetComponent<Firearms>();
        firearms = GameObject.Find("AK47").GetComponent<Firearms>();
        Debug.Log(firearms);
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        UpdateAmmoInfo(firearms.GetCurrentAmmo, firearms.GetCurrentMaxAmmoCarried);
    }
    private void UpdateAmmoInfo(int _ammo, int _remaningAmmo)
    {
        text1.text = _ammo + "/" + _remaningAmmo;
    }
}
