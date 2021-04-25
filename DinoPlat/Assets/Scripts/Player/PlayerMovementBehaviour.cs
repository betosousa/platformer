using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DinoPlat.Player
{
    /// <summary>
    /// Component to control player movement, handling player input for walk and jump
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        private const string SPEED_ANIM_PARAM = "Speed";
        private const string IS_GROUNDED_ANIM_PARAM = "IsGrounded";
        private const string IS_RUN_ANIM_PARAM = "IsRun";
        private const string JUMP_ANIM_TRIGGER = "Jump";
        private const float FEET_RADIUS = .05f;
        private Vector2 _movementInput;
        private bool _isGrounded;
        private bool _jump;
        private bool _isRun;
        private Rigidbody2D _body;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Transform _feet;


        private float YSpeed { get { return (_isGrounded && _jump) ? _playerData.JumpForce : _body.velocity.y; } }
        private float XSpeed
        {
            get
            { 
                // player wants to run
                if (_isGrounded && _isRun) 
                    return _playerData.RunSpeed * _movementInput.x;
                // player wants to walk
                else if (_isGrounded) 
                    return _playerData.WalkSpeed * _movementInput.x;
                // player is in mid air
                else return _body.velocity.x;
            }
        }

        private void OnEnable()
        {
            _body = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Stores player input to be used on fixed update
        /// </summary>
        /// <param name="context"></param>
        public void OnMovement(InputAction.CallbackContext context)
        {
            _movementInput = context.ReadValue<Vector2>();
        }

        /// <summary>
        /// Stores player jump input and activates animation trigger
        /// </summary>
        /// <param name="context"></param>
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _jump = true;
                _animator.SetTrigger(JUMP_ANIM_TRIGGER);
            }
        }

        /// <summary>
        /// Stores player run input 
        /// </summary>
        /// <param name="context"></param>
        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.performed) _isRun = true;
            if (context.canceled) _isRun = false;
        }

        private void FixedUpdate()
        {
            // Set velocity
            _body.velocity = new Vector2(XSpeed, YSpeed);

            // Reset variables
            _isGrounded = Physics2D.OverlapCircle(_feet.position, FEET_RADIUS, _playerData.GroundLayers);
            _jump = false;
        }

        private void Update()
        {
            _spriteRenderer.flipX = _body.velocity.x < 0;
            _animator.SetFloat(SPEED_ANIM_PARAM, Mathf.Abs(_body.velocity.x));
            _animator.SetBool(IS_GROUNDED_ANIM_PARAM, _isGrounded);
            _animator.SetBool(IS_RUN_ANIM_PARAM, _isRun);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_feet.position, FEET_RADIUS);
        }
#endif
    }
}