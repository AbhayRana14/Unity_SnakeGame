using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    public GameObject fruit_pickup, bomb_pickup;
    private float min_X = -4.25f, max_X = 4.25f, min_Y = -2.26f, max_y = 2.26f;
    private float z_Pos = 5.8f;
    private Text score_Text;
    private int scoreCount;

    
    // Start is called before the first frame update
    void Awake()
    {
        makeInstance();
    }
    void Start()
    {
        score_Text = GameObject.Find("Score").GetComponent<Text>();
        Invoke("StartSpawning",0.5f);
    }
    // Update is called once per frame
    void makeInstance()
    {
        if (instance == null) {
            instance = this;
        }
    }
    void StartSpawning() {

        StartCoroutine(SpawnPickups());
    }
    public void cancelSpawning() {
        CancelInvoke("StartSpawning");
    }

    IEnumerator SpawnPickups() {
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));
        if (Random.Range(0, 10) >= 2)
        {
            Instantiate(fruit_pickup, new Vector3(Random.Range(min_X, max_X), Random.Range(min_Y, max_y), z_Pos), Quaternion.identity);
        }
        else {
            Instantiate(bomb_pickup, new Vector3(Random.Range(min_X, max_X), Random.Range(min_Y, max_y), z_Pos), Quaternion.identity);

        }

        Invoke("StartSpawning", 0f);

    }

    public void increaseScore() {
        scoreCount++;
        score_Text.text = "SCORE: " + scoreCount;
    }
}
