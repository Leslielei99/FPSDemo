using Scripts.Weapon;
using UnityEngine;

public class CroshairUI : MonoBehaviour
{
    public RectTransform Reticle;
    public CharacterController CharacterController;

    public float OriginalSize;
    public float TargetSize;

    public Firearms firearms;
    private float currentSize;

    private void Update()
    {
        bool tmp_IsMoving = CharacterController.velocity.magnitude > 3.9;
        bool _isAiming = firearms.IsAiming;
        if (tmp_IsMoving && !_isAiming)
        {
            currentSize = Mathf.Lerp(currentSize, TargetSize, Time.deltaTime * 10);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, OriginalSize, Time.deltaTime * 10);
        }

        Reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }
}