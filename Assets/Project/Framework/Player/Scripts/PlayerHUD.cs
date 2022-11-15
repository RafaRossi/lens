using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
     [SerializeField] private Image aimIndicator;
     
     [SerializeField] private TMP_Text hudText;
     
     public Image AimIndicator
     {
          get => aimIndicator;
          private set => aimIndicator = value;
     }

     public void SetHUDText(string text)
     {
          hudText.text = text;
     }
}
