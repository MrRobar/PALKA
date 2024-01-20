using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {
	private CustomInputActions inputActions;

	public override void Awake() {
		base.Awake();
		inputActions = new CustomInputActions();
	}

	public Vector2 GetMovementInput() {
		return inputActions.Player.MovementDirection.ReadValue<Vector2>();
	}

	public Vector2 GetMouseDelta() {
		return inputActions.Player.MouseDelta.ReadValue<Vector2>();
	}

	public bool IsSprinting() {
		return inputActions.Player.Sprint.IsPressed();
	}

	public bool IsJumping() {
		return inputActions.Player.Jump.IsPressed();
	}
	private void OnEnable() {
		inputActions.Enable();
	}

	private void OnDisable() {
		inputActions.Disable();
	}
}
