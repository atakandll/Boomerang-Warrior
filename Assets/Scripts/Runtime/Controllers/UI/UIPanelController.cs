using System.Collections.Generic;
using Runtime.Enums.UI;
using UnityEngine;

namespace Runtime.Controllers.UI
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<GameObject> uiPanels = new List<GameObject>();

        #endregion

        #endregion

        internal void ChangePanel(UIPanelTypes panelTypes, bool panelStatus)
        {
            uiPanels[(int)panelTypes].SetActive(panelStatus);
        }
    }
}