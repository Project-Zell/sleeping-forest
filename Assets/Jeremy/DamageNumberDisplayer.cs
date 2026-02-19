using Coollel.Stephen;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DamageNumberDisplayer : MonoBehaviour
{

    //Action
    public Transform damageText;
    public int numberCount;
    public float numberLifetime;
    private float time;
    private Transform numberPrefab;
    private Queue<float> activeNumbers;
    private Queue<float> reserveNumbers;
    [SerializeField]
    private BaseEnemy enemy;

    //private void OnEnable() => enemy.OnTakeDamage += DisplayDamageNumber;
    //private void OnDisable() => enemy.OnTakeDamage -= DisplayDamageNumber;
    public void Start()
    {
        damageText.GetComponent<DamageTextFlavor>().displayScript = this;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) DisplayDamageNumber(30);
        if (time < 0)
        {
            RemoveNumber(damageText.transform);
            return;
        }
    }
    public void AddNumber()
    {
        //to be implemented
    }
    public void DisplayDamageNumber(float damage)
    {
        //show damage number at position
        damageText.gameObject.SetActive(true);
        var damageUI = damageText.GetComponent<TextMeshProUGUI>();
        damageUI.text = damage.ToString();
        damageUI.color = Color.yellow;
        damageText.GetComponent <DamageTextFlavor>().lifetime = numberLifetime;
    }
    public void RemoveNumber(Transform thisNumber)
    {
        thisNumber.gameObject.SetActive(false);
    }

}
