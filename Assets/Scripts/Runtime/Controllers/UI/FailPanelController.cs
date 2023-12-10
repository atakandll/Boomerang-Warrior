using Runtime.Enums.UI;
using Runtime.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Controllers.UI
{
    public class FailPanelController : MonoBehaviour
    {
        [SerializeField]
        private UIManager manager;

        [SerializeField]
        private TextMeshProUGUI lastDeathScore;

        [SerializeField]
        private Button tryAgainButton;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            InitButton();
        }

        internal void SetDeathScore(int value)
        {
            lastDeathScore.text = value.ToString();
        }

        private void InitButton()
        {
            tryAgainButton.onClick.AddListener(delegate { ArangePanelStatus(UIPanelTypes.FailPanel); });
        }

        private void ArangePanelStatus(UIPanelTypes uIPanelType)
        {
            manager.ChangePanelStatusOnPressTryAgain(uIPanelType);
        }
    }
}