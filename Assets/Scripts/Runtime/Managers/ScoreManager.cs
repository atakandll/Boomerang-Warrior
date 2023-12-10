using Runtime.Data.UnityObject;
using Runtime.Data.ValueObject;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        #region Self Variables

        #region Private Variables

        private string _dataPath = "Data/CD_ScoreData";
        private ScoreData _scoreData;



        #endregion

        #endregion
        
        private void Awake()
        {
            GetData();
        }

        public void GetData()
        {
            _scoreData = Resources.Load<CD_ScoreData>(_dataPath).ScoreData;
        }

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            ScoreSignals.Instance.onScoreTaken += OnScoreTaken;
            ScoreSignals.Instance.onDeathScoreTaken += OnDeathScoreTaken;
        }

        private void UnsubscribeEvents()
        {
            ScoreSignals.Instance.onScoreTaken -= OnScoreTaken;
            ScoreSignals.Instance.onDeathScoreTaken -= OnDeathScoreTaken;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void Start()
        {
            InitData();
        }

        private void InitData()
        {
            UISignals.Instance.onlastCoinScore?.Invoke(_scoreData.LastCoinScore);
            UISignals.Instance.onlastCoinScore?.Invoke(_scoreData.LastDeathScore);
        }

        private void OnScoreTaken()
        {
            _scoreData.LastCoinScore++;

            UISignals.Instance.onlastCoinScore?.Invoke(_scoreData.LastCoinScore);
        }

        private void OnDeathScoreTaken()
        {
            _scoreData.LastDeathScore++;

            UISignals.Instance.onLastDeathScore?.Invoke(_scoreData.LastDeathScore);
        }
    }
}