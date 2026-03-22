using UnityEngine;
using System.Collections.Generic;

public class CoinPoolManager : MonoBehaviour
{
    public static CoinPoolManager Instance { get; private set; }

    public GameObject coinPrefab;

    private ObjectPool coinPool;
    private List<Vector3> coinStartPositions;
    private List<GameObject> activeCoins;

    void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Record starting positions of scene-placed coins
        GameObject[] existingCoins = GameObject.FindGameObjectsWithTag("Coin");
        coinStartPositions = new List<Vector3>();

        foreach (GameObject coin in existingCoins)
        {
            coinStartPositions.Add(coin.transform.position);
            Debug.Log($"Coin instantiated: {coin.name}");
            Destroy(coin); // remove original scene coins
        }

        // Create the pool with enough initial objects
        coinPool = new ObjectPool(coinPrefab, coinStartPositions.Count);
        activeCoins = new List<GameObject>();

        // Spawn all coins
        SpawnAllCoins();
    }

    public void SpawnAllCoins()
    {
        foreach (Vector3 position in coinStartPositions)
        {
            GameObject coin = coinPool.Get();  // automatically activated in Get()
            coin.transform.position = position;

            // Track active coins
            activeCoins.Add(coin);
            Debug.Log($"Coin spawned/activated: {coin.name}");
        }
    }

    public void ReturnCoin(GameObject coin)
{
    // No null coins
    if (coin == null) return;

    // Return to pool (deactivates)
    coinPool.Return(coin);

    // Remove from active list if it’s still there
    activeCoins.Remove(coin);
}

    public void ResetAllCoins()
{
    // Iterate over a copy to avoid modification errors
    foreach (GameObject coin in activeCoins.ToArray())
    {
        if (coin != null)
        {
            coinPool.Return(coin);
        }
    }
    activeCoins.Clear();
    // Respawn all coins
    SpawnAllCoins();
    Debug.Log("All coins reset to pool");

}
}
