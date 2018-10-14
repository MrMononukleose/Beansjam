using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    private const float LeftXMinPosition = -7.5f;
    private const float LeftXMaxPosition = -3.5f;

    private const float RightXMinPosition = 3.5f;
    private const float RightXMaxPosition = 7.5f;

    private const float MinYPosition = -4.1f;
    private const float MaxYPosition = 4.1f;

    public float SpawnMinRange = 1f;
    public float SpawnMaxRange = 2f;

    public GameObject Zuckerwatte;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        SpawnAtRandomPosition(LeftXMinPosition, LeftXMaxPosition, MinYPosition, MaxYPosition);
        SpawnAtRandomPosition(RightXMinPosition, RightXMaxPosition, MinYPosition, MaxYPosition);

        Invoke("Spawn", Random.Range(SpawnMinRange, SpawnMaxRange));
    }

    private void SpawnAtRandomPosition(float xMin, float xMax, float yMin, float yMax)
    {
        var spawnPoint = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

        var hitColliders = Physics.OverlapSphere(spawnPoint, 20);
        if (hitColliders.Length > 0)
        {
            // Dieser Platz ist nicht frei, nochmal probieren
            SpawnAtRandomPosition(xMin, xMax, yMin, yMax);
        }
        else
        {
            // Platz ist frei, wir spawnen
            Instantiate(Zuckerwatte, spawnPoint, Quaternion.identity);
        }
    }
}