using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{

public Text MyscoreText;
private int ScoreNum;


    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score : " + ScoreNum;
    }

      void OnTriggerEnter(Collider other)
  {

        if (tag == "MyApple")
        {
            ScoreNum +=1;
            Destroy(gameObject);
            MyscoreText.text = "Score" + ScoreNum;
        }
  }
}
