using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public Rigidbody PlayerRB;
    private int Score = 0;
    private int TotalCoin;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        TotalCoin = GameObject.FindGameObjectsWithTag("coin").Length;
        ScoreUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hazard"))
        {
            SceneManager.LoadScene("GameLose");
        }

        else if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            ++Score;
            ScoreUpdate();
        }
    }

    private void ScoreUpdate()
    {
        ScoreText.text = "Score: " + Score;
        if (Score == TotalCoin)
        {
            LoadScenes();
        }
    }

    private void LoadScenes()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Lvl1")
        {
            SceneManager.LoadScene("Lvl2");
        }

        else if (currentScene.name == "Lvl2")
        {
            SceneManager.LoadScene("GameWin");
        }
    }
}
