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
        [SerializeField]
        private Transform levelholder;

        [SerializeField]
        private LevelLoaderCommand levelLoaderCommand;

        [SerializeField]
        private ClearActiveLevelCommand clearActiveLevelCommand;

        private int _levelID;

        private string _dataPath = "Data/Cd_LevelData";

        private LevelData _levelData;

        private void Awake()
        {
            //GetLevelData();
        }

        private void GetLevelData() => _levelData = Resources.Load<Cd_LevelData>(_dataPath).LevelData[_levelID];

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += OnLevelInitilize;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onFail += OnFail;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitilize;
            CoreGameSignals.Instance.onFail -= OnFail;
            CoreGameSignals.Instance.onPlay -= OnPlay;
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

        private void OnLevelInitilize()
        {
            levelLoaderCommand.InitializeLevel(_levelID, levelholder);
        }

        private void OnPlay()
        {
        }

        private void OnFail()
        {
            clearActiveLevelCommand.ClearActiveLevel(levelholder);

            CoreGameSignals.Instance.onReset?.Invoke();
        }

        private void OnReset()
        {
            SaveLoadSignals.Instance.onSave?.Invoke();
        }

        

        
    }
}