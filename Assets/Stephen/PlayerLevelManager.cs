using System;
using UnityEngine;

namespace Coollel.Stephen
{
    public class PlayerLevelManager : MonoBehaviour
    {
        public int Level { get; private set; }
        public int CurrectEXP { get; private set; }
        public int LevelUpEXP { get; private set; }

        public static event Action<float> OnGainEXP;
        public static event Action<int> OnLevelUpEXPChanged;
        public static event Action OnStartLevelUp;

        void Start()
        {
            Level = 1;
            CurrectEXP = 0;
            LevelUpEXP = 30;
        }

        public void GainEXP(int amount)
        {
            CurrectEXP += amount;
            var expPersantage = (float)CurrectEXP / (float)LevelUpEXP;
            OnGainEXP?.Invoke(expPersantage);
            while (CurrectEXP >= LevelUpEXP)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level += 1;
            OnStartLevelUp?.Invoke();
            CurrectEXP -= LevelUpEXP;
            LevelUpEXP += 10;
            print("Level up EXP not set");
            OnLevelUpEXPChanged?.Invoke(LevelUpEXP);
        }
    }
}