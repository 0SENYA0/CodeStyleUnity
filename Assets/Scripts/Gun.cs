using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class Gun : MonoBehaviour
{
	private const float DamageDistance = 0.5f;
	
	[SerializeField] private float _delay;
	[SerializeField] private Bullet _bullet;
	[SerializeField] private Transform _target;

	private WaitForSeconds _waitForSeconds;
	private Transform _transform;

	private void Awake()
	{
		_transform = transform;
		_waitForSeconds = new WaitForSeconds(_delay);
	}

	private void Start() =>
		StartCoroutine(Shoot());

	private IEnumerator Shoot()
	{
		while (enabled)
		{
			Vector3 direction = (_target.position - _transform.position).normalized;
			Bullet bullet = Instantiate(_bullet, _transform.position + direction, Quaternion.identity);

			bullet.SetVelocity(direction);

			yield return _waitForSeconds;
		}
	}
}