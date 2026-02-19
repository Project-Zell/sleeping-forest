using UnityEngine;

public class DamageTextFlavor : MonoBehaviour
{
    public DamageNumberDisplayer displayScript;
    public float lifetime;
    // Update is called once per frame
    void Update()
    {
        lifetime-= Time.deltaTime;
        if (lifetime < 0)
        {
            displayScript.RemoveNumber(transform);
        }
    }
}
