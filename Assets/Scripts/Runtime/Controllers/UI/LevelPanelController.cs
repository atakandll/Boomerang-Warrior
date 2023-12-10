using Runtime.Extensions;
using Runtime.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Runtime.Controllers.UI
{
    public class LevelPanelController : MonoBehaviour
    {
        [SerializeField]
        private UIManager manager;

        [SerializeField]
        private TextMeshProUGUI gold;

        [SerializeField]
        private TextMeshProUGUI deadCount;

        [SerializeField]
        private Image image;

        internal void InitGoldScore(int value)
        {
            gold.text = value.ToString();
        }

        internal void PrintHealth(float health)
        {
            image.fillAmount = SelfExtetions.Map(health, 0, 100, 0, 1);
        }

        internal void InitDeathScore(int value)
        {
            deadCount.text = value.ToString();
        }
    }
}