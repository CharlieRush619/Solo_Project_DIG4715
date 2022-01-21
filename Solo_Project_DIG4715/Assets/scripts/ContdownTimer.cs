using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ContdownTimer : MonoBehaviour
{

float currentTime = 0f;
float startingTime = 10f;
public Text countdownText;
public GameObject other;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            Destroy(other);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
