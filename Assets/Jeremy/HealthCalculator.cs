using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Coolel.Jeremy
{
    public class HealthCalculator : MonoBehaviour, IArmor
    {
        public float maxHealth;
        public float health; //can be extrapolated to the bar
        public float healthPercent;
        public float armor;
        public Image healthBar;
        public TextMeshProUGUI healthText;
        public float ArmorValue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (maxHealth < 0)
            {
                maxHealth = 100;
            }
            health = maxHealth;
            healthBar.fillAmount = 1;
            healthText.text = $"{health} / {maxHealth} ({healthPercent * 100}%)";
        }

        // Update is called once per frame
        void Update()
        {
            healthPercent = health / maxHealth;
        
        }

        public void TakeDamage(float incomingDamage) //make sure to use trigger stay to not cause weird interactions
        {
            health -= incomingDamage;
            healthBar.fillAmount = healthPercent;
        }

        public void RecoverHealth(float incomingRecovery)
        {
            health += incomingRecovery;
            healthBar.fillAmount = healthPercent;
        }
        public void CalculateArmor(float armorValue)
        {
            throw new System.NotImplementedException();
        }

       }
 }
