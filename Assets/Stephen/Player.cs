using System;
using UnityEngine;

namespace Coollel.Stephen
{
    public class Player : MonoBehaviour, IArmor
    {
        public float ArmorValue { get; set; }
        public int Health { get; set; }

        public int CurrentHealth => Health;

        public int MaxHealth => throw new NotImplementedException();


        public void CalculateArmor(float armorValue)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(float damage)
        {
            Health -= (int)damage;
        }

        public void TakeDamage(int damage)  
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                TakeDamage(1.0f);
            }
        }
    }
}