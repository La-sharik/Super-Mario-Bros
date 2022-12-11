using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public int countPointStart = 0;
    public Text countPointText;

    // Start is called before the first frame update
    void Start()
    {
        countPointText.text = countPointStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        countPointStart = GameManager.Instance.coins * 100 + GameManager.Instance.stars * 1000 + GameManager.Instance.mushrooms * 1000 + GameManager.Instance.koopa * 400 + GameManager.Instance.goomba * 200;
        countPointText.text = countPointStart.ToString();
    }
}
