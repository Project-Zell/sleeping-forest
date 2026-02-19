using UnityEngine;

public class PlayerLevelProgression : MonoBehaviour
{
    public int CurrentExperience { get; private set; }
    public int MaxExperience { get; private set; }
    public int CurrentLevel { get; private set; }

    [SerializeField] private LevelUpChannel _levelUpChannel;
    [SerializeField] private ExperienceGainChannel _experienceGainChannel;

    [SerializeField] private int _baseMaxExperience = 5;
    [SerializeField] private int _flatMaxExperienceRise = 10;
    [SerializeField] private float _progressiveExperienceRise = 0.15f;

    private void Awake()
    {
        CurrentExperience = 0;
        MaxExperience = _baseMaxExperience;
        CurrentLevel = 1;
    }

    private void Start() => _experienceGainChannel.RaiseEvent(new ExperienceGainContainer(CurrentExperience, MaxExperience));

    public void GainExperience(int value)
    {
        CurrentExperience += value;
        while(CurrentExperience > MaxExperience)
        {
            LevelUp();
        }
        _experienceGainChannel.RaiseEvent(new ExperienceGainContainer(CurrentExperience, MaxExperience));
    }

    private void LevelUp()
    {
        CurrentExperience -= MaxExperience;
        CurrentLevel++;
        MaxExperience = GetMaxExperience();

        _levelUpChannel.RaiseEvent(CurrentLevel);
    }

    private int GetMaxExperience()
    {
        var levelMod = CurrentLevel - 1;
        return Mathf.FloorToInt(_baseMaxExperience + (levelMod * _flatMaxExperienceRise) + (levelMod * _progressiveExperienceRise));
    }
}
