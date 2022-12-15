using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart = 400;
    public Text timerText;    
    private bool musicPlay = false;
    private GameObject player;
    public AudioClip audioClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        timerText.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= (Time.deltaTime) * 2;
        timerText.text = Mathf.Round(timeStart).ToString();
        if(timeStart < 10 && musicPlay == false){
            audioSource.PlayOneShot(audioClip);
            musicPlay = true;
        }
    }
    public void ResetTime() {
        timeStart = 400;
    }
}
