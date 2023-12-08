using UnityEngine;

public class CameraSpringUtility
{
    public Vector3 Values;

    private float frequence;
    private float damp;
    private Vector3 dampVaules;

    #region test
    public CameraSpringUtility(float _frequence, float _damp)
    {
        frequence = _frequence;
        damp = _damp;
    }

    public void UpdateSpring(float _deltaTime, Vector3 _target)
    {
        Values -= _deltaTime * frequence * dampVaules;
        dampVaules = Vector3.Lerp(dampVaules, Values - _target, damp * _deltaTime);
    } 
    #endregion


}