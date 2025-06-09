using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class AchievementsDisplayer : MonoBehaviour
{
    [SerializeField]
    private Achievement onDisplay;
    [Space]
    [SerializeField]
    private Color lockedColor, unlockedColor;
    [Header("Reference")]
    [SerializeField]
    private Image background;
    [SerializeField]
    private TextMeshProUGUI title, description, progress;
    [Space]
    [SerializeField]
    private Image iconRef;
    [SerializeField]
    private Sprite lockedIcon;
    [SerializeField,Space]
    private bool playAnimation;
    [SerializeField]
    private float enterDuration;
    private Vector3 oldScale;
    [SerializeField]
    private bool exitAnimation;
    [SerializeField]
    private float stayDuration,exitDuration;
    [SerializeField]
    private bool destroyAfter;
    private void OnEnable()
    {
        if (playAnimation)
        {
            oldScale = transform.localScale;
            transform.localScale = Vector3.zero;
            transform.DOScale(oldScale, enterDuration).SetEase(Ease.OutElastic);

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45f));
            transform.DORotate(new Vector3(0, 0, 0f), enterDuration).SetEase(Ease.OutElastic);//.SetAutoKill(false).PlayBackwards();
            if (exitAnimation)
            {
                Vector3 pos = transform.position;
                pos += new Vector3(pos.x+(Screen.width/2),0,0);
                transform.DOMove(pos, exitDuration).SetEase(Ease.OutExpo).SetDelay(stayDuration).OnComplete(()=> { if (destroyAfter) { Destroy(gameObject); }; });
            }
        }

    }
    public void Display(Achievement toShow)
    {
        onDisplay = toShow;
        title.text = toShow.Name;
        description.text = toShow.Description;

        if (onDisplay.IsUnlocked)
        {
            iconRef.sprite = toShow.icon;
            background.color = unlockedColor;
        }
        else
        {
            iconRef.sprite = lockedIcon;
            background.color = lockedColor;

        }
    }

}
