using System.Linq;
using Derkii.FindByInterfaces;
using Derkii.MVVM.Abstraction;
using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Sample
{
    public class MainScreen : Screen<CountViewModel>
    {
        [SerializeField] private ClickVisualEffect _clickVisualEffect, _errorVisualEffect;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Button _removeButton, _addButton;
        [SerializeField] private Canvas _canvas;
        private Camera _camera;
        public override bool IsMultiplyWindow => false;

        protected override void OnBind(CountViewModel viewModel)
        {
            _camera = Camera.main;
            _viewModel = viewModel;
            _addButton.onClick.AddListener(() =>
            {
                _viewModel.AddCount();
                Spawn(_clickVisualEffect)
                    .SetText("+" + $"{Mathf.Abs(_viewModel.Count)}");
            });
            _removeButton.onClick.AddListener(() =>
            {
                if (!_viewModel.RemoveCount())
                {
                    Spawn(_errorVisualEffect).SetText("Minimum value is 0");
                }
                else
                {
                    Spawn(_clickVisualEffect)
                        .SetText("-" + $"{Mathf.Abs(_viewModel.Count)}");
                }
            });
            _viewModel.Bind(new CountModel());
            _viewModel.ChangeCount(3);
            _viewModel.OnCurrentCountChanged += (value) => { _text.text = value.ToString(); };
        }

        private ClickVisualEffect Spawn(ClickVisualEffect clickVisualEffect)
        {
            var visualEffectInstance = LeanPool.Spawn(clickVisualEffect, _canvas.transform);

            visualEffectInstance.transform.localPosition = Random.insideUnitCircle * 300f;
            return visualEffectInstance;
        }
    }
}