using UnityEngine;

public class Mover : MonoBehaviour
{
	[SerializeField] private Transform _points;
	[SerializeField] private float _speed;

	private Transform[] _places;
	private int _indexPlace;
	private Transform _transform;
	private Vector3 _targetPosition;

	private void Awake()
	{
		_transform = transform;
		
		_places = new Transform[_points.childCount];

		for (int i = 0; i < _points.childCount; i++)
			_places[i] = _points.GetChild(i).GetComponent<Transform>();
	}

	private void Update()
	{
		_targetPosition = _places[_indexPlace].position;
		_transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, _speed * Time.deltaTime);

		if (_transform.position == _targetPosition)
			Rotate();
	}

	private void Rotate()
	{
		_indexPlace++;

		if (_indexPlace == _places.Length)
			_indexPlace = 0;

		Vector3 target = _places[_indexPlace].transform.position;
		
		transform.forward = target - transform.position;
	}
}