using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    MapGrid map;

    [SerializeField]
    int currentLevel;

    [SerializeField]
    EnemyPool slowEnemyPool;

    [SerializeField]
    EnemyPool fastEnemyPool;

    [SerializeField]
    ObjectPool<CargoShip> shipPool;

    [SerializeField]
    GameEvent onLevelComplete;

    [SerializeField]
    private ObjectPool<GoalNode> goalPool;

    [SerializeField]
    ObjectPool<MappedObject> obstaclePool;

    int numShips;
    int shipsReachedGoal;

List<Vector2Int> takenPositions = new List<Vector2Int>();

    public void IncrementLevel()
    {
        currentLevel++;
    }

    public void CheckLevelCompletion()
    {
        shipsReachedGoal++;

        //Debug.LogWarning($"Level Complete: {shipsReachedGoal >= numShips}");
        if (shipsReachedGoal >= numShips)
        {
            onLevelComplete.Invoke();
        }
    }

    public void CreateLevel()
    {
        ClearStuff();
        int numEnemiesToSpawn = 0;
        EnemyPool enemyToSpawn = null;
        if (currentLevel > 1)
        {
            //Spawn Enemies;
            enemyToSpawn = currentLevel > 6 ? fastEnemyPool : slowEnemyPool;
            numEnemiesToSpawn = Random.Range(1, 4);
        }

        int numShipSpawns;
        //Ship spawns
        if (currentLevel > 8)
        {
            numShipSpawns = 3;
        }
        else if (currentLevel > 4)
        {
            numShipSpawns = 2;
        }
        else
        {
            numShipSpawns = 1;
        }

        shipsReachedGoal = 0;
        numShips = numShipSpawns;
        //The smart thing to do would be to prevent spawns to the same position, but time...
        SpawnEnemies(enemyToSpawn, numEnemiesToSpawn);
        SpawnShips(numShipSpawns);
        SpawnGoal();
    }

    private void SpawnShips(int numToSpawn)
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            Vector2Int pos;
do
{
 
            //Left side spawn
            int x = Random.Range(-Mathf.Abs(map.Dimensions.x), -Mathf.Abs(map.Dimensions.x) + 3);
            int y = Random.Range(-Mathf.Abs(map.Dimensions.y), Mathf.Abs(map.Dimensions.y) + 1);
pos = new Vector2Int(x,y);
}while(takenPositions.Contains(pos))
takenPositions.Add(pos);
            var ship = shipPool.GetObject();
            ship.MapPosition = pos;
            ship.gameObject.SetActive(true);
        }
    }

    private void SpawnGoal()
    {
Vector2Int pos;
do
{
        //Right side spawn
        int x = Random.Range(Mathf.Abs(map.Dimensions.x) - 2, Mathf.Abs(map.Dimensions.x) + 1);
        int y = Random.Range(-Mathf.Abs(map.Dimensions.y), Mathf.Abs(map.Dimensions.y) + 1);
pos = new Vector2Int(x,y);
}while(takenPositions.Contains(pos))
takenPositions.Add(pos);

        var goal = goalPool.GetObject();
        goal.MapPosition = pos;
        goal.gameObject.SetActive(true);

    }

    void SpawnEnemies(EnemyPool poolToUse, int numToSpawn)
    {
        if (poolToUse == null)
        {
            return;
        }
        for (int i = 0; i < numToSpawn; i++)
        {
Vector2Int pos;
do
{
            bool posX = HelperFunctions.IsHeads();
            bool posY = HelperFunctions.IsHeads();
            //So enemies cannot spawn kill player..hopefully;
            int x = posX ? Random.Range(2, Mathf.Abs(map.Dimensions.x) + 1) : Random.Range(-Mathf.Abs(map.Dimensions.x), -1);
            int y = posY ? Random.Range(2, Mathf.Abs(map.Dimensions.y) + 1) : Random.Range(-Mathf.Abs(map.Dimensions.y), -1);
pos = new Vector2Int(x,y);
}while(takenPositions.Contains(pos))
takenPositions.Add(pos);


            var enemy = poolToUse.GetObject();
            enemy.MapPosition = pos;
            enemy.gameObject.SetActive(true);
        }
    }

    public void ClearStuff()
    {
        fastEnemyPool.DisableAll();
        slowEnemyPool.DisableAll();
        shipPool.DisableAll();
        goalPool.DisableAll();
        obstaclePool.DisableAll();
        takenPositions.Clear();
    }


}
