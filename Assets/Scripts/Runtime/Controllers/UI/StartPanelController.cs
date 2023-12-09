using System;
using Runtime.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Controllers.UI
{
    public class StartPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIManager manager;
        [SerializeField] private Button startButton;
 
        #endregion

        #endregion

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
      
    }
}