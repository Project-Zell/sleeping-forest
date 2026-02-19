using Coolel.Jeremy;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    public int expAmount = 10; // 取得できる経験値
    public float baseSpeed = 1.5f; // 初期速度
    public float acceleration = 0.005f; // 加速度係数
    public float maxSpeed = 2.5f; // 最大速度（任意）
    private Transform player;
    private bool isAttracted = false;
    private float attractionStartTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (isAttracted && player != null)
        {
            float elapsedTime = Time.time - attractionStartTime;
            float currentSpeed = baseSpeed + acceleration * Mathf.Pow(elapsedTime, 0.7f);

            transform.position = Vector3.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PickupRange"))
        {
            isAttracted = true; // 吸い寄せ開始
        }
    }
}