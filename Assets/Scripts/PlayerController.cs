using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float stopRnage = 10f;
    private int heroLives, heroScore;
    public float speed;

    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        heroLives = 3;
        heroScore = 0;
        ShowLives();
        ShowScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -stopRnage)
        {
            transform.position = new Vector3(-stopRnage, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > stopRnage)
        {
            transform.position = new Vector3(stopRnage, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -stopRnage)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -stopRnage);
        }
        else if (transform.position.z > stopRnage)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, stopRnage);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }
    }

    private void ShowLives()
    {
        Debug.Log($"{heroLives}");
    }

    private void ShowScore()
    {
        Debug.Log($"{heroScore}");
    }

    private void ChangeLiveOrScore(int liveOrScore, string who, int change)
    {
        if (who == "Live")
        {
            liveOrScore = heroLives;
            liveOrScore += change;
            ShowLives();
        }
        else if (who == "Score")
        {
            liveOrScore = heroScore;
            liveOrScore += change;
            ShowScore();
        }
    }
}