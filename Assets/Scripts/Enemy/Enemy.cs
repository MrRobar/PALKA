using System;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField] private Transform targetTransform;
	[SerializeField] private float maxMoveSpeed;
	[SerializeField] private float maxAcceleration;
	[SerializeField] private float steeringWeight;
	private Vector3 _velocity;
	private Vector3 _acceleration;
	
	public void Init(Transform targetTransform) {
		this.targetTransform = targetTransform;
	}

	private void FixedUpdate() {
		HandleMovement();
	}

	private void HandleMovement() {
		_acceleration += GetSeekSteering();
		
		_velocity += _acceleration;
		_acceleration = Vector3.zero;

		if (_velocity.magnitude >= maxMoveSpeed) {
			_velocity = _velocity.normalized * maxMoveSpeed;
		}
		
		transform.position += _velocity * (maxAcceleration * Time.deltaTime);
		transform.LookAt(targetTransform);
	}
	
	
	
	private Vector3 GetSeekSteering() {
		Vector3 direction = targetTransform.position - transform.position;

		direction.Normalize();
		
		return (direction * maxAcceleration) / steeringWeight;
	}
}
