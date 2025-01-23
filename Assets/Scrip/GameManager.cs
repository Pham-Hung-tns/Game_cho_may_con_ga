using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public GameObject enemy;
    public Vector3 old_pos = Vector3.zero;
    public float spawnIntervalMin = 2f; // Thời gian sinh tối thiểu (giây)
    public float spawnIntervalMax = 3f; // Thời gian sinh tối đa (giây)
    public float moveSpeed = 2f; // Tốc độ di chuyển ngang của enemy
    private float spawnTimer; // Bộ đếm thời gian để sinh enemy mới

    void Start()
    {
        // Đặt thời gian ngẫu nhiên để sinh enemy đầu tiên
        spawnTimer = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    void Update()
    {
        // Đếm ngược thời gian
        spawnTimer -= Time.deltaTime;

        // Khi thời gian hết, lấy enemy từ pool và kích hoạt
        if (spawnTimer <= 0)
        {
            SpawnEnemy();
            spawnTimer = Random.Range(spawnIntervalMin, spawnIntervalMax); // Reset lại thời gian
        }
    }

    void SpawnEnemy()
    {
        // Lấy một enemy từ pool
        GameObject newEnemy = ObjectPool.Instance.Initialization(enemy);

        // Đặt vị trí và reset trạng thái của enemy
        newEnemy.transform.position = old_pos;
        newEnemy.GetComponent<EnemyMovement>().moveSpeed = moveSpeed;

        // Kích hoạt enemy
        newEnemy.SetActive(true);
    }
}