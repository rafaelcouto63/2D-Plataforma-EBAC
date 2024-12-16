using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
   [Header("Player")]
   public GameObject player;

   [Header("Enemies")]
   public List<GameObject> enemies;
   
   [Header("References")]
   public Transform stratPoint;

   [Header("Animmation")]
    public float duration = 0.2f;
    public float delay = 0.05f;
    public Ease ease = Ease.OutBack;

   private GameObject _currentPlayer;

   private void Start()
   {
      Init();
   }

   public void Init () 
   {
     SpawnPlayer();
   }

   private void SpawnPlayer () 
   {
     _currentPlayer = Instantiate(player);
     _currentPlayer.transform.position = stratPoint.transform.position;
     _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From();
   }
}
