using Player;
using UnityEngine;

namespace StateMachine
{
    public class ZigZagEnemyBehavior : MonoBehaviour
    {
        //Tous les SerializeField
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _detectionRadius = 3f;
        [SerializeField] private float _zigzagAmplitude = 2f;
        [SerializeField] private float _zigzagFrequency = 2f;
        [SerializeField] private float _timeElapsed = 0f;

        //Tous les private
        private IState _currentState;
        private ZigZagEnemyStateMachineData _stateMachineData;

        private void Start()
        {
            _stateMachineData = new ZigZagEnemyStateMachineData
            {
                EnemyTransform = transform,
                PlayerTransform = FindObjectOfType<PlayerMovement>().transform,
                Speed = _speed,
                DetectionRadius = _detectionRadius,
                ZigzagAmplitude = _zigzagAmplitude,
                ZigzagFrequency = _zigzagFrequency,
                TimeElapsed = _timeElapsed
            };

            _currentState = new ZigZagState();
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