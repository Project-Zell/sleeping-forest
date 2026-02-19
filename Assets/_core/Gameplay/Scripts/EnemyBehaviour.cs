using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private Transform _playerTransform;

    public void Initiazlie(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    public void MoveToValidNavMesh(Vector3 targetLocation)
    {
        _agent.Warp(targetLocation);
        transform.LookAt(_playerTransform);
    }

    private void Update()
    {
        if(_playerTransform != null)
            _agent.destination = _playerTransform.position;
    }
}