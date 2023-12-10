using System.Collections.Generic;
using Runtime.Enums.UI;
using UnityEngine;

namespace Runtime.Controllers.UI
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> uiPanels = new List<GameObject>();

        internal void ChangePanel(UIPanelTypes panelType, bool panelStatus)
        {
            uiPanels[(int)panelType].SetActive(panelStatus);
        }
    }
}