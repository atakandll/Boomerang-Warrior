using System;
using Runtime.Commands;
using Runtime.Data.UnityObject;
using Runtime.Data.ValueObject;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Transform levelHolder;
        [SerializeField] private LevelLoaderCommand LevelLoaderCommand;
        [SerializeField] private LevelDestroyerCommand LevelDestroyerCommand;

        #endregion

        #region Private Variables

        private int _levelID;
        private string _dataPath = "Data/CD_LevelData";
        private LevelData _levelData;

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onLevelInitialize += OnLevelInitialize;
            CoreGameSignals.Instance.onFail += OnFail;
            CoreGameSignals.Instance.onReset += OnReset;
        }
        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitialize;
            CoreGameSignals.Instance.onFail -= OnFail;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void Start()
        {
            CoreGameSignals.Instance.onLevelInitialize?.Invoke();
        }
        private void GetLevelData() => _levelData = Resources.Load<CD_LevelData>(_dataPath).LevelData[_levelID];

        private void OnPlay()
        {
            
        }
        private void OnLevelInitialize()
        {
            LevelLoaderCommand.Execute(_levelID, levelHolder);
            
        }

        private void OnFail()
        {
            LevelDestroyerCommand.Execute(levelHolder);
            CoreGameSignals.Instance.onReset?.Invoke();
        }

        private void OnReset()
        {
            //save
        }

        

        
    }
}