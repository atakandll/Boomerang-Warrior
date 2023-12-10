using Runtime.Data.UnityObject;
using Runtime.Data.ValueObject;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private string _dataPath = "Data/Cd_ScoreData";

        private ScoreData _scoreData;

        private void Awake()
        {
            GetData();
        }

        public void GetData()
        {
            _scoreData = Resources.Load<Cd_ScoreData>(_dataPath).ScoreData;
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
            UISignals.Instance.onPrintLastGoldScore?.Invoke(_scoreData.LastGoldScore);
            UISignals.Instance.onPrintLastDeathScore?.Invoke(_scoreData.LastDeathScore);
        }

        private void OnScoreTaken()
        {
            _scoreData.LastGoldScore++;

            UISignals.Instance.onPrintLastGoldScore?.Invoke(_scoreData.LastGoldScore);
        }

        private void OnDeathScoreTaken()
        {
            _scoreData.LastDeathScore++;

            UISignals.Instance.onPrintLastDeathScore?.Invoke(_scoreData.LastDeathScore);
        }
    }
}