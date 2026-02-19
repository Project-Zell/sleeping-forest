using UnityEngine;
using UnityEngine.UIElements;

public class ShowNumbers : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = transform.position;
            position.y += 360f;

            NumbersAction.EnemyTakeDamage.Invoke(999, position);
        }
    }
}
