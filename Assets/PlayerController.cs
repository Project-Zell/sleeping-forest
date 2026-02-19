using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _baseSpeed;

    private Rigidbody _rbBody;

    public void Start() => _rbBody = GetComponent<Rigidbody>();

    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(h, 0, v).normalized;

        move.y = _rbBody.linearVelocity.y;
        _rbBody.linearVelocity = move * 3;
    }
    public void Damage()
    {
        _rbBody.AddForce(transform.forward * (-3f), ForceMode.Impulse);
    }
}
