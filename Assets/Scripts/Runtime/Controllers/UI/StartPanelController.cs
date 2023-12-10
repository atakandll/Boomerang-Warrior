using System;
using Runtime.Enums.UI;
using Runtime.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Controllers.UI
{
    public class StartPanelController : MonoBehaviour
    {
        [SerializeField]
        private UIManager manager;

        [SerializeField]
        private Button startButton;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            InitButton();
        }

        private void InitButton()
        {
            startButton.onClick.AddListener(delegate { ArangeStartPanelStatus(); });
        }

        private void ArangeStartPanelStatus()
        {
            manager.ChangePanelStatusOnPlay();
        }

        private void ArangePanelStatus(UIPanelTypes uIPanelType)
        {
            manager.ChangePanelStatusOnStartAsSetting(uIPanelType);
        }
      
    }
}