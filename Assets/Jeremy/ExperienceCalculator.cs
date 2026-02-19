using UnityEngine;
using System;
using UnityEngine.Events;
namespace Coolel.Jeremy
{
    public class ExperienceCalculator
    {
        public UnityEvent levelUpEvents = new UnityEvent();
        public int level;
        public float nextLevelExperience;
        public float experience; //can be extrapolated to the bar
        public float experiencePercentage;

        void InitializeExperience()
        {
            level = 1;
            ExperienceCalculation(level);
        }

        public void LevelUp()
        {
            level++;
            ExperienceCalculation(level);
            levelUpEvents.Invoke();
            experience -= nextLevelExperience;
            CollectExperience(0);
        }
        public void CollectExperience(float experienceValue) //make sure to use trigger stay to not cause weird interactions
        {
            experience += experienceValue;
            experiencePercentage = experience / nextLevelExperience;
        }
        public void ExperienceCalculation(int level)
        {
            //whatever magic you want here
            nextLevelExperience = 100 + 50 * level;
        }
    }
}
