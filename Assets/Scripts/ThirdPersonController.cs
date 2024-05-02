using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    //input 
    private ThirdPersonActionsAsset PlayerActionsAsset;
    public ThirdPersonActionsAsset.PlayerActions PlayerActions { get; private set; }
    public ThirdPersonActionsAsset.UIActions UIActions { get; private set; }

    private InputAction move;

    //movement
    private Rigidbody rb;
    [SerializeField] private float movementForce = 1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField] private Camera playerCamera;
    private Animator _animator;
    [SerializeField] private UIManager uIManager;

    [SerializeField] Collider weaponCollider;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        _animator = this.GetComponent <Animator>();
        PlayerActionsAsset = new ThirdPersonActionsAsset();
        PlayerActions = PlayerActionsAsset.Player;
        UIActions = PlayerActionsAsset.UI;//////
    }

    private void OnEnable()
    {
        PlayerActionsAsset.Player.Jump.started += DoJump;
        PlayerActionsAsset.Player.Attack.started += DoAttack;
        move = PlayerActionsAsset.Player.Move;
        PlayerActionsAsset.Player.Enable();
        PlayerActionsAsset.UI.Enable();
        // PlayerActionsAsset.Player.Interact.started += DoInteract;
        UIActions.OpenQ.started += uIManager.ShowQuestMenu;//////
    }

    private void OnDisable()
    {
        PlayerActionsAsset.Player.Jump.started -= DoJump;
        PlayerActionsAsset.Player.Attack.started -= DoAttack;
        PlayerActionsAsset.Player.Enable();
        PlayerActionsAsset.UI.Disable();
        UIActions.OpenQ.started -= uIManager.ShowQuestMenu;
        // PlayerActionsAsset.Player.Interact.started -= DoInteract;
    }

    private void FixedUpdate()
    {
        PhysicsSetUp();
    }

    private void PhysicsSetUp()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if(move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction,Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
            _animator.SetFloat("Height", 0.6f);
        }
        else
            _animator.SetFloat("Height", 0f);
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        { 
            return true; 
        }
        else
        { 
            return false; 
        }
    }

    private void DoAttack(InputAction.CallbackContext context)
    {
        _animator.SetTrigger("attack");
        weaponCollider.gameObject.SetActive(true);
        Invoke("StopAttack", 0.001f);
    }

    private void StopAttack()
    {
        _animator.SetTrigger("stoped");
        weaponCollider.gameObject.SetActive(true);
    }

}
