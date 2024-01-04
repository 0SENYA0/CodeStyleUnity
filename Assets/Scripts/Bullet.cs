using System;
using UnityEngine;

namespace DefaultNamespace
{
	[RequireComponent(typeof(Rigidbody))]
	public class Bullet : MonoBehaviour
	{
		[SerializeField] private float _speed;

		private Rigidbody _rigidbody;

		private void Awake() =>
			_rigidbody = GetComponent<Rigidbody>();

		public void SetVelocity(Vector3 direction)
		{
			_rigidbody.transform.up = direction;
			_rigidbody.velocity = direction * _speed;
		}
	}
}