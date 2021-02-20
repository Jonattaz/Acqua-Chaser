using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Advertisements;

public class Menu : MonoBehaviour, IUnityAdsListener
{
    // Variables
    [SerializeField] private AudioMixer audioMixer;

    string googlePlay_ID = "4016627";
    string mySurfacingId = "rewardedVideo";

    bool gameMode = true;


    // Start is calledbefore the first frame update 
    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(googlePlay_ID, gameMode);

    }

    // Shows the ad
    public void DisplayInterstitialAD()
    {
        Advertisement.Show();
    }


    // Load Scenes
    public void LoadPhase(int cena)
    {
        SceneManager.LoadScene(cena);
    }

    // Function that controls the exit game
    public void ExitGame()
    {
        Application.Quit();

    }


    // Controls the volume mixer 
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    // Method to reset high score
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("");

    }


    public void DisplayVideoAd()
    {
        Advertisement.Show(mySurfacingId);
    }


    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            Debug.LogWarning("BOA");

        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            Debug.LogWarning("Vacilo");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}











