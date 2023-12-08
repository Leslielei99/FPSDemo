using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private Image image;
    private float tmp_tima;
    private CharaterPlayer charaterPlayer;

    private void Start()
    {
        charaterPlayer = GameObject.Find("Player").GetComponent<CharaterPlayer>();
        Debug.Log(charaterPlayer.Health);
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.fillAmount = (float)((float)charaterPlayer.Health / 100f);
    }
}