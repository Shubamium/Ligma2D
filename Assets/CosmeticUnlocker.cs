using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticUnlocker : MonoBehaviour
{

    public GameObject[] cosmeticsUIs;
    public RewardedAdsButton adsInit;

    public void UnlockCosmetics()
    {
        if(adsInit != null)
        {
            adsInit.ShowAd();
            adsInit.OnAdsCompleted = null;
            adsInit.OnAdsCompleted += Unlock;
        }
    }

    private void Unlock()
    {
        foreach (GameObject cos in cosmeticsUIs)
        {
           if(cos != null) cos.SetActive(true);
        }
    }
}
