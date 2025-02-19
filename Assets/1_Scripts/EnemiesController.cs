using UnityEngine;

public class EnemiesController : Singletone<EnemiesController>
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemyPrefab;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Vector3 positionSpawn = player.transform.position;
        positionSpawn.x += Random.Range(-20, 20);
        positionSpawn.z += Random.Range(-20, 20);

        Enemy newEnemy = Instantiate(enemyPrefab, positionSpawn, Quaternion.identity);
        newEnemy.SetPlayer = player;
    }

    public void EnemyDeath()
    {
        GameController.Instance.CountEnemy();
        SpawnEnemy();
    }
}
