using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

namespace StateMachine
{
    //[RequireComponent(typeof(EnemyMovements))]
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float _verticalSpeed = 3f;
        [SerializeField] private float _horizontalSpeed = 1.5f;
        [SerializeField, Range(0, 10)] private float _visionRange = 5f;
        [SerializeField, Range(0, 180)] private float _visionAngle = 90f; //l'angle de vision de l'ennemi en degrès
        [SerializeField] private Transform _player;

        public bool _canSeePlayer = false;

        private IState _currentState;
        private EnemyStateMachineData _enemyStateMachineData;

        private void Start()
        {
            _enemyStateMachineData = new EnemyStateMachineData()
            {
                enemyTransform = transform,
                enemyVerticalSpeed = _verticalSpeed,
                enemyHorizontalSpeed = _horizontalSpeed,
                playerTransform = _player,
            };
            _currentState = new PassiveState();
        }

        public void TransitionTo(IState newState)
        {
            if (_currentState != null)
            {
                _currentState.Exit(_enemyStateMachineData);
            }
            _currentState = newState;
            _currentState.Enter(_enemyStateMachineData);
        }

        public void Update()
        {
            Debug.Log(_canSeePlayer);
            if (_player != null)
            {
                CheckIfPlayerIsVisible();
            }

            if (_currentState != null)
            {
                _currentState.Update(_enemyStateMachineData);
            }

            if(_canSeePlayer)
            {
                TransitionTo(new AttackState());
                Debug.Log("TransitionTo(new AttackState());");
            }
            else
            {
                Debug.Log("TransitionTo(new PassiveState());");
                TransitionTo(new PassiveState());
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        private void CheckIfPlayerIsVisible()
        {
            Vector3 distance = _player.position - transform.position;

            if (distance.sqrMagnitude < _visionRange * _visionRange)
            {
                if (Vector3.Dot(distance.normalized, transform.forward) <= (_visionAngle - 180) / 180)
                {
                    _canSeePlayer = true;
                }
            }
            _canSeePlayer = false;
        }

        //private void OnDrawGizmos()
        //{
        //    Vector3 distance = _player.position - transform.position;

        //    if (distance.sqrMagnitude < _visionRange * _visionRange)
        //    {
        //        if (Vector3.Dot(distance.normalized, -transform.up) <= (_visionAngle - 180) / 180)
        //        {
        //            Handles.color = Color.green;
        //        }
        //    }

        //    Handles.DrawWireDisc(transform.position, transform.forward, _visionRange);
        //}
    }
}