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
    public GameObject Zuckerwatte3P;
    public GameObject Kotze;
    public GameObject Stein;

    private GameObject[] spawnObjects;

    private void Start()
    {
        spawnObjects = new []{ Zuckerwatte, Zuckerwatte, Zuckerwatte3P };
        Spawn();
        SpawnKotze();
    }

    private void Spawn()
    {
        var spawnObject = spawnObjects[Random.Range(0, spawnObjects.Length)];

        SpawnAtRandomPosition(LeftXMinPosition, LeftXMaxPosition, MinYPosition, MaxYPosition, spawnObject);
        SpawnAtRandomPosition(RightXMinPosition, RightXMaxPosition, MinYPosition, MaxYPosition, spawnObject);

        SpawnAtRandomPosition(LeftXMinPosition, LeftXMaxPosition, MinYPosition, MaxYPosition, Stein);
        SpawnAtRandomPosition(RightXMinPosition, RightXMaxPosition, MinYPosition, MaxYPosition, Stein);

        Invoke("Spawn", Random.Range(SpawnMinRange, SpawnMaxRange));
    }

    private void SpawnKotze()
    {
        SpawnAtRandomPosition(LeftXMinPosition, LeftXMaxPosition, MinYPosition, MaxYPosition, Kotze);
        SpawnAtRandomPosition(RightXMinPosition, RightXMaxPosition, MinYPosition, MaxYPosition, Kotze);

        Invoke("SpawnKotze", Random.Range(3, 5));
    }

    private void SpawnAtRandomPosition(float xMin, float xMax, float yMin, float yMax, GameObject gObject)
    {
        var spawnPoint = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

        var hitColliders = Physics.OverlapSphere(spawnPoint, 20);
        if (hitColliders.Length > 0)
        {
            // Dieser Platz ist nicht frei, nochmal probieren
            SpawnAtRandomPosition(xMin, xMax, yMin, yMax, gObject);
        }
        else
        {
            // Platz ist frei, wir spawnen
            Instantiate(gObject, spawnPoint, Quaternion.identity);
        }
    }
}