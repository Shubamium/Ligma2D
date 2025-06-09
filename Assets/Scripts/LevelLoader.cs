using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    [SerializeField]private InterstitialAdsInitializer adsInit;
    public void LoadScene(int toLoad) 
    {
        //if there's an ads module
        if (adsInit != null)
        {
            adsInit.OnAdsCompleted += () => { SceneManager.LoadScene(toLoad); };
            adsInit.ShowAd();
        }
        else
        {
            SceneManager.LoadScene(toLoad);
        }
    }
    
    public void SetPrefAndLoad(int toSet)
    {
        PlayerPrefs.SetInt("LoadCode", toSet);
    }
    public void ExitApp()
    {
        Application.Quit();
    }
    public void DeleteSave()
    {
        SaveSystemNew.ClearData();
        GameObject target = GameObject.FindGameObjectWithTag("Displayer");
        target.SetActive(false);
        target.SetActive(true);
      
    }
}
