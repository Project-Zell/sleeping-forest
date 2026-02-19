public struct ExperienceGainContainer 
{
    public float CurrentExperience { get; private set; }
    public float MaxExperience { get; private set; }

    public ExperienceGainContainer(int currentExperience, int maxExperience)
    {
        CurrentExperience = currentExperience;
        MaxExperience = maxExperience;
    }
}
