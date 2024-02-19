using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Enums;
using static Enums.GameState;
using Signals;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers.Enemy
{
    public class EnemyMotionController : MonoBehaviour
    {
        private Rigidbody _enemyBody;
        private GameState _gameState;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _enemyBody = GetComponent<Rigidbody>();
            _gameState = GameState.Stopped;
        }

        #region EventSubscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState += OnChangeGameState;
            CoreGameSignals.Instance.onReset += ResetTransform;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState -= OnChangeGameState;
            CoreGameSignals.Instance.onReset -= ResetTransform;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void FixedUpdate()
        {
            if (_gameState == GameState.Playing)
            {
                MoveEnemy();
            }
        }

        private void OnChangeGameState(GameState state)
        {
            _gameState = state;
            if (_gameState == GameState.Playing)
            {
                _enemyBody.isKinematic = false;
            }
        }

        private void MoveEnemy()
        {
            if (_enemyBody.position.x > 0 && _enemyBody.position.y < 10)
            {
                MoveEnemyLeft();
            }
            else if (_enemyBody.position.x < 0 && _enemyBody.position.y < 10)
            {
                MoveEnemyRight();
            }
        }

        private void MoveEnemyLeft()
        {
            _enemyBody.velocity = new Vector3(-2.5f, 12, 0);
        }

        private void MoveEnemyRight()
        {
            _enemyBody.velocity = new Vector3(2.5f, 12, 0);
        }

        private void ResetTransform()
        {
            _enemyBody.isKinematic = true;
            transform.position = new Vector3(3, 6, 0);
            transform.DORotate(new Vector3(0, 0, 0), 0.1f);
        }
    }
}
