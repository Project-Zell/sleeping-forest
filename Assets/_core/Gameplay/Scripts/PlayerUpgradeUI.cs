using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerUpgradeUI : GameStateRequester
{
    [SerializeField] private LevelUpChannel _levelUpChannel;
    [SerializeField] private UpgradeManager _upgradeManager;
    [SerializeField] private PlayerUpgradeSelecorElement[] _selectionsElements;
    [SerializeField] private SpriteAtlas _upgradeSpriteAtlas;
    [SerializeField] private GameObject _upgradesHolder;
    [SerializeField] private Canvas _canvas;
    private int _queuedLevelUps = 0;

    private List<BasicStatUpgradeTree> _levelUpChoices = new();

    private void OnEnable() => _levelUpChannel.Subscribe(RequestLevelUpChoice);
    private void OnDisable() => _levelUpChannel.Unsubscribe(RequestLevelUpChoice);

    private void Start() => CloseSelectionWindow();

    public void RequestLevelUpChoice(int _)
    {
        _queuedLevelUps++;
        CheckQueue();
    }

    public void CheckQueue()
    {
        if (_queuedLevelUps > 0)
        {
            _levelUpChoices = _upgradeManager.GetLevelUpOptions(3);
            if(_levelUpChoices.Count > 0)
            {
                ShowSelection();
            }
            else
            {
                _queuedLevelUps--;
                CheckQueue();
            }
        }
        else
        {
            RequestUnpause();
            CloseSelectionWindow();
        }
    }

    public void ShowSelection()
    {
        for (int i = 0; i < _selectionsElements.Length; i++)
        {
            if (i >= _levelUpChoices.Count)
            {
                _selectionsElements[i].Disable();
                continue;
            }
            else
            {
                _selectionsElements[i].Enable();
            }
            var upgrade = _levelUpChoices[i];
            var sprite = _upgradeSpriteAtlas.GetSprite($"{upgrade.NameKey}");
            _selectionsElements[i].ShowUpgradeSelection(upgradeName: upgrade.NameKey, upgradeDescription: upgrade.DescriptionKey, sprite: sprite);
        }
        _canvas.enabled = true;
        RequestPause();
    }

    public void CloseSelectionWindow()
    {
        _canvas.enabled = false;
    }

    public void SelectUpgrade(int index)
    {
        _upgradeManager.Upgrade(_levelUpChoices[index]);
        _queuedLevelUps--;
        CheckQueue();
    }
}
