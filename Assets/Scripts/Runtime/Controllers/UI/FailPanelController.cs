using Runtime.Enums.UI;
using Runtime.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Controllers.UI
{
    public class FailPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIManager manager;
        [SerializeField] private TextMeshProUGUI lastDeathScore;
        [SerializeField] private Button tryAgainButton;

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
        internal void SetLastDeathScore(int value) => lastDeathScore.text = value.ToString();
        
        private void InitButton()
        {
            tryAgainButton.onClick.AddListener(delegate { ArangePanelStatus(UIPanelTypes.FailPanel); });
        }

        private void ArangePanelStatus(UIPanelTypes panelTypes)
        {
            manager.ChangePanelStatusOnPressTryAgain(panelTypes);
        }
    }
}