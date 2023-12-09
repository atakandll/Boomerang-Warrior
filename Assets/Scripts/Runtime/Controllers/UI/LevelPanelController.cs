using Runtime.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Runtime.Controllers.UI
{
    public class LevelPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TextMeshProUGUI coin;
        [SerializeField] private TextMeshProUGUI deathCount;
        [SerializeField] private Image image;

        #endregion

        #endregion

        internal void SetCoinScore(int coinValue) =>  coin.text = coinValue.ToString();

        internal void SetDeathScore(int deathCountvalue) => deathCount.text = deathCountvalue.ToString();

        internal void SetFillValueHealth(float health)
        {
            image.fillAmount = CalculationRationHealth(health,0,100,0,1);
        }

        private float CalculationRationHealth(float value, float inMin, float inMax, float outMin, float outMax)
        {
            float result = (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
            return result;
        }
    }
}