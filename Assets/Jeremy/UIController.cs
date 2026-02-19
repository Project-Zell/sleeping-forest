using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;

namespace Coolel.Jeremy
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance { get; private set; }
        //public event Action<int> W;
        //public UnityEvent<int> UnityEvent;
        public ExperienceCalculator experienceCalculator;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);
        }
        void Start()
        {
            experienceCalculator = GetComponent<ExperienceCalculator>();
        }
        /*
         * HealthManager
         * SkillHolder
         * Cooldownmanager
         * Timer
         * Objectives
         */

        Tuple<int, string, int> e = Tuple.Create(0, "", 0);

        struct Vector
        {

        }

        public void Test(int x, int y, int z, int w)
        {

        }

        public void Test(Tuple<int, string, int> e)
        {
            
        }

    }

}
