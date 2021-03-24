using UnityEngine;

/*
 * This is the "Player manager".
 * On Awake Initialize() gets called. This sets the base
 * player values to the ones in GameplayParameters ScriptableObject.
 * PlayerMovement() and Jump() are referenced in InputManager 
 * but the logic is here.
 */
namespace Player
{
    public class PlayerAction : Player
    {
        GroundDetection _gd;
        Rigidbody _rb;
        Collider _col;

        private float _zPosition;
        private bool _isGrounded;
        public float jumpForce;
        public float gravityMultiplier = 2f;

        private Vector3 gravity = new Vector3(0, -9.81f, 0);

        private void Awake()
        {
            Initialize();

            _gd = GetComponent<GroundDetection>();
            _rb = GetComponent<Rigidbody>();
            _col = GetComponent<Collider>();

            _zPosition = transform.position.z;
        }

        public void Jump()
        {
            if (_isGrounded)
                _rb.velocity = new Vector3(_rb.velocity.x, jumpForce, _rb.velocity.z);
        }

        public void PlayerMovement(float x)
        {
            x *= speed;

            _rb.AddForce(gravity * gravityMultiplier, ForceMode.Acceleration);

            Vector3 movePosition = transform.right * x;
            Vector3 newMovePosition = new Vector3(movePosition.x, _rb.velocity.y, _zPosition);

            _rb.velocity = newMovePosition;

            _isGrounded = _gd.IsGrounded(_col);

            if (_isGrounded)
                gravityMultiplier = 2f;
        }
    }
}
