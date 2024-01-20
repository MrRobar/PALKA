
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {
	[SerializeField] private CharacterController characterController;
	[SerializeField] private Transform bottomPoint;
	[SerializeField] private float movementSpeed;
	[SerializeField] private float sprintMultiplier;
	[SerializeField] private Transform cameraTransform;
	[SerializeField] private Vector3 cameraMaxAngle;
	[SerializeField] private float mouseSensitivity;
	[SerializeField] private float jumpForce;
	[SerializeField] private float gravity = -9.81f;
	private const float InitialVelocityOfJump = -2f;
	private Vector3 _velocity;
	private Vector2 _mouseDelta;
	private Vector3 _movementDirection;
	private bool _isSprinting;
	private Quaternion _newPlayerRotation;
	private Quaternion _newCameraRotation;

	private void Start() {
		Cursor.visible = false;

		_newPlayerRotation = transform.localRotation;
		_newCameraRotation = cameraTransform.localRotation;
	}
	private void Update() {
		HandleInput();
	}

	private void FixedUpdate() {
		HandleMovement();
		HandleRotation();
		HandleJumping();
		HandlePhysics();

	}

	private void HandlePhysics() {

	}

	private void HandleInput() {
		var temp = InputManager.Instance.GetMovementInput();
		_movementDirection = (transform.forward * temp.y + cameraTransform.right * temp.x).normalized;

		_isSprinting = InputManager.Instance.IsSprinting();

		_mouseDelta = InputManager.Instance.GetMouseDelta();

	}

	private void HandleMovement() {
		float sprintingMultiplier = _isSprinting ? sprintMultiplier : 1;
		Vector3 movement = _movementDirection * (movementSpeed * sprintingMultiplier * Time.deltaTime);

		characterController.Move(movement);

		if (IsGrounded() && _velocity.y < 0) {
			_velocity.y = InitialVelocityOfJump;
		}

		_velocity.y += gravity * Time.deltaTime;

		characterController.Move(_velocity * Time.deltaTime);
	}

	private void HandleRotation() {
		var rotation = _mouseDelta * (mouseSensitivity * Time.deltaTime);

		_newCameraRotation *= Quaternion.Euler(Vector2.left * rotation.y);
		_newCameraRotation = Utils.ClampRotation(_newCameraRotation, cameraMaxAngle);

		_newPlayerRotation *= Quaternion.Euler(Vector2.up * rotation.x);

		cameraTransform.localRotation = _newCameraRotation;
		transform.localRotation = _newPlayerRotation;
	}

	private void HandleJumping() {
		if (InputManager.Instance.IsJumping() && IsGrounded()) {
			_velocity.y = Mathf.Sqrt(jumpForce * InitialVelocityOfJump * gravity);
		}
	}

	private bool IsGrounded() {
		return Physics.Raycast(bottomPoint.position, Vector3.down, 0.1f);
	}

	private void OnDrawGizmos() {
		Gizmos.DrawLine(bottomPoint.position, bottomPoint.position + Vector3.down * 0.05f);
	}
}
