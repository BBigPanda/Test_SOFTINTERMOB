using UI.Presenters;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public interface IHeroView
    {
        void SetValues(int health, int mana, int power);
    }

    public class HeroView : MonoBehaviour, IHeroView
    {
        [SerializeField] private UIDocument _uiDocument;
        private HeroPresenter _heroPresenter;

        private Label _healthLabel;
        private Label _manaLabel;
        private Label _powerLabel;
        private Button _upgradeButton;

        public void Initialize(HeroPresenter heroPresenter)
        {
            _heroPresenter = heroPresenter;
            var root = _uiDocument.rootVisualElement;
            _healthLabel = root.Q<Label>("_health");
            _manaLabel = root.Q<Label>("_mana");
            _powerLabel = root.Q<Label>("_power");
            _upgradeButton = root.Q<Button>("_buttonUpgrade");
            _upgradeButton.clicked += _heroPresenter.OnUpgradeButtonClicked;
        }
        
        
        public void SetValues(int health, int mana, int power)
        {
            _healthLabel.text = $"Health: {health}";
            _manaLabel.text = $"Mana: {mana}";
            _powerLabel.text = $"Power: {power}";
        }
    }
}