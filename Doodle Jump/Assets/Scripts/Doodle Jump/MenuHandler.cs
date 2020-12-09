using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [Header("Music")]
    public AudioMixer masterAudio;
    public Slider musicSlider;
    public Toggle muteToggle;

    [Header("Sound Effects")]
    public Slider SFXSlider;
    public AudioSource jumpFX;

    public GameObject options;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            options.SetActive(true);
        }
        else if(options.activeSelf == false)
        {
            Time.timeScale = 1;
        }
    }

    public void ChangeScene(int sceneIndex) //Function to change from Main Menu scene to the game scene
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame() //Function to quit the game
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void JumpFX()
    {
        jumpFX.Play(); //jump sound will play when jump
    }

    public void ChangeVolume(float volume)
    {
        //float volume is the parameter name of the volume on the AudioMixer in Unity
        masterAudio.SetFloat("volume", volume);
    }

    public void SetSFXVolume(float SFXVol)
    {
        masterAudio.SetFloat("SFXVol", SFXVol);
    }

    public void ToggleMute(bool isMuted) //Function to mute volume when toggle is active
    {
        //string reference isMuted connects to the AudioMixer master group Volume and isMuted parameters in Unity
        if (isMuted)
        {
            //-80 is the minimum volume
            masterAudio.SetFloat("isMutedVolume", -80);
        }
        else
        {
            //20 is the maximum volume
            masterAudio.SetFloat("isMutedVolume", 20);
        }
    }
}
