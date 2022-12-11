using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveCounter : MonoBehaviour
{
    public int liveCounterStart = 3;
    public Text liveCounterText;
    // Start is called before the first frame update
    void Start()
    {
        liveCounterText.text = liveCounterStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        liveCounterStart = GameManager.Instance.lives;
        liveCounterText.text = liveCounterStart.ToString();
    }
}
