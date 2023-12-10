using System;
using Runtime.Controllers.UI;
using Runtime.Enums.UI;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private UIPanelController uIPanelController;

        [SerializeField]
        private LevelPanelController levelPanelController;

        [SerializeField]
        private FailPanelController failPanelController;

        private int _lastDeathScore;

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onPrintLastGoldScore += OnInitLastGoldScore;
            UISignals.Instance.onHealthDecrase += OnHealthDecrase;
            UISignals.Instance.onPrintLastDeathScore += OnPrintLastDeathScore;

            CoreGameSignals.Instance.onLevelInitialize += OnLevelInitilize;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onFail += OnFail;
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onPrintLastGoldScore -= OnInitLastGoldScore;
            UISignals.Instance.onHealthDecrase -= OnHealthDecrase;
            UISignals.Instance.onPrintLastDeathScore -= OnPrintLastDeathScore;

            CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitilize;
            CoreGameSignals.Instance.onFail -= OnFail;
            CoreGameSignals.Instance.onPlay -= OnPlay;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void OnOpenPanel(UIPanelTypes panelType) => uIPanelController.ChangePanel(panelType, true);

        internal void OnClosePanel(UIPanelTypes panelType) => uIPanelController.ChangePanel(panelType, false);

        private void OnLevelInitilize()
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

        public void ChangePanelStatusOnStartAsSetting(UIPanelTypes uIPanelType)
        {
            OnOpenPanel(uIPanelType);

            OnClosePanel(UIPanelTypes.StartPanel);
        }

        private void OnFail()
        {
            failPanelController.SetDeathScore(_lastDeathScore);

            OnOpenPanel(UIPanelTypes.FailPanel);
            
            OnClosePanel(UIPanelTypes.LevelPanel);
        }

        internal void ChangePanelStatusOnPressTryAgain(UIPanelTypes uIPanelType)
        {
            OnClosePanel(uIPanelType);

            OnOpenPanel(UIPanelTypes.StartPanel);

            CoreGameSignals.Instance.onLevelInitialize?.Invoke();

            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        private void OnHealthDecrase(float health)
        {
            levelPanelController.PrintHealth(health);
        }

        internal void OnInitLastGoldScore(int value)
        {
            levelPanelController.InitGoldScore(value);
        }

        private void OnPrintLastDeathScore(int value)
        {
            _lastDeathScore = value;
            levelPanelController.InitDeathScore(value);
        }





    }
}