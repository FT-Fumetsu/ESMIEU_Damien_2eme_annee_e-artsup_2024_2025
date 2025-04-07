using Player;
using UnityEngine;

namespace StateMachine
{
    public class AttackEnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _detectionRadius = 2f;
        private IState _currentState;
        private AttackEnemyStateMachineData _stateMachineData;

        private void Start()
        {
            _stateMachineData = new AttackEnemyStateMachineData
            {
                EnemyTransform = transform,
                PlayerTransform = FindObjectOfType<PlayerMovement>().transform,
                Speed = _speed,
                DetectionRadius = _detectionRadius
            };

            _currentState = new PassiveState();
            _currentState.Enter(_stateMachineData);
        }

        private void Update()
        {
            IState newState = _currentState.Update(_stateMachineData);
            if (newState != null)
            {
                _currentState.Exit(_stateMachineData);
                _currentState = newState;
                _currentState.Enter(_stateMachineData);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}