using System.Collections;
using UnityEngine;

public class FPCharacterControllerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private Animator characterAnimator;
    private Vector3 movementDirection;
    private Transform characterTransform;
    private float velocity;
    private bool isCrouched;
    private float originHeight;
    public float SprintingSpeed;

    [ContextMenuItem("Add speed", "AddSpeed")]
    public float WalkSpeed;

    public float SprintingSpeedWhenCrouched;
    public float WalkSpeedWhenCrouched;
    public float Gravity = 9.8f;
    public float JumpHeight;
    public float CrouchHeight = 1f;
    public float CurrentSpeed { get; private set; }

    private float tmp_time;

    private void AddSpeed()
    {
        WalkSpeed += 1;
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        //        characterAnimator = GetComponentInChildren<Animator>();
        characterTransform = transform;
        originHeight = characterController.height;
    }

    private void Update()
    {
        // SendPosition();
        CurrentSpeed = WalkSpeed;
        if (characterController.isGrounded)
        {
            var tmp_Horizontal = Input.GetAxis("Horizontal");
            var tmp_Vertical = Input.GetAxis("Vertical");
            movementDirection =
                characterTransform.TransformDirection(new Vector3(tmp_Horizontal, 0, tmp_Vertical)).normalized;
            if (isCrouched)
            {
                CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintingSpeedWhenCrouched : WalkSpeedWhenCrouched;
            }
            else
            {
                CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintingSpeed : WalkSpeed;
            }

            if (Input.GetButtonDown("Jump"))
            {
                movementDirection.y = JumpHeight;
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                var tmp_CurrentHeight = isCrouched ? originHeight : CrouchHeight;
                StartCoroutine(DoCrouch(tmp_CurrentHeight));
                isCrouched = !isCrouched;
            }

            if (characterAnimator != null)
                characterAnimator.SetFloat("Velocity",
                    CurrentSpeed * movementDirection.normalized.magnitude,
                    0.15f,
                    Time.deltaTime);
        }

        movementDirection.y -= Gravity * Time.deltaTime;
        var tmp_Movement = CurrentSpeed * Time.deltaTime * movementDirection;
        characterController.Move(tmp_Movement);
    }

    private IEnumerator DoCrouch(float _target)
    {
        float tmp_CurrentHeight = 0;
        while (Mathf.Abs(characterController.height - _target) > 0.1f)
        {
            yield return null;
            characterController.height =
                Mathf.SmoothDamp(characterController.height, _target,
                    ref tmp_CurrentHeight, Time.deltaTime * 5);
        }
    }

    internal void SetupAnimator(Animator _animator)
    {
        Debug.Log($"Execute! the animator is empty??? {_animator == null}");
        characterAnimator = _animator;
    }

    private void SendPosition()
    {
        // tmp_time += Time.deltaTime;
        // if (tmp_time > 0.05)
        // {
        //     PlayerInfo p = new PlayerInfo(this.name, transform.position);
        //     // UserClient.SendMessage(new Message("UpdatePlayerInfo", JsonConvert.SerializeObject(p)));
        //     tmp_time = 0;
        // }
    }
}