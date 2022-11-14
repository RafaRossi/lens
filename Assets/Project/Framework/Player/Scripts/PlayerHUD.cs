using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
     [SerializeField] private Image aimIndicator;
     public Image AimIndicator
     {
          get => aimIndicator;
          private set => aimIndicator = value;
     }
     
     
}
