using System;
using Runtime.Controllers.UI;
using Runtime.Enums.UI;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIPanelController uiPanelController;
        [SerializeField] private LevelPanelController levelPanelController;
        [SerializeField] private FailPanelController failPanelController;
        
        #endregion

        #region Private Variables

        private int _lastDeathScore;

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onlastCoinScore += OnlastCoinScore;
            UISignals.Instance.onHealth += OnHealth;
            UISignals.Instance.onLastDeathScore += OnLastDeathScore;
            
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onLevelInitialize += OnLevelInitialize;
            CoreGameSignals.Instance.onFail += OnFail;
            
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onlastCoinScore -= OnlastCoinScore;
            UISignals.Instance.onHealth -= OnHealth;
            UISignals.Instance.onLastDeathScore -= OnLastDeathScore;
            
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitialize;
            CoreGameSignals.Instance.onFail -= OnFail;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        private void OnOpenPanel(UIPanelTypes panelTypes) => uiPanelController.ChangePanel(panelTypes, true);
        internal void OnClosePanel(UIPanelTypes panelTypes) => uiPanelController.ChangePanel(panelTypes, false);

        private void OnLevelInitialize()
        {
            OnOpenPanel(UIPanelTypes.StartPanel);
        }

        internal void ChangePanelStatusOnPlay()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        private void OnPlay()
        {
            OnClosePanel(UIPanelTypes.StartPanel);
            OnOpenPanel(UIPanelTypes.LevelPanel);
        }

        public void ChangePanelStatusOnStartAsSetting(UIPanelTypes panelTypes)
        {
            OnOpenPanel(panelTypes);
            OnClosePanel(UIPanelTypes.StartPanel);
        }

        private void OnFail()
        {
            failPanelController.SetLastDeathScore(_lastDeathScore);
            OnOpenPanel(UIPanelTypes.FailPanel);
        }
        internal void ChangePanelStatusOnPressTryAgain(UIPanelTypes panelTypes)
        {
           OnClosePanel(panelTypes);
           OnOpenPanel(UIPanelTypes.StartPanel);
           
           CoreGameSignals.Instance.onLevelInitialize?.Invoke();
           CoreGameSignals.Instance.onPlay?.Invoke();
        }

        private void OnlastCoinScore(int value) => levelPanelController.SetCoinScore(value);
        private void OnHealth(float value) => levelPanelController.SetFillValueHealth(value);

        private void OnLastDeathScore(int value)
        {
            _lastDeathScore = value;
            levelPanelController.SetDeathScore(value);
            
        }





    }
}