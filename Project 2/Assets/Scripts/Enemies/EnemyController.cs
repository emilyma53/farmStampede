﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  #region Editor Variables
  // [SerializeField]
  // private int m_MaxHealth;

  [SerializeField]
  private float m_Speed;

  [SerializeField]
  private float m_Damage;

  // [SerializeField]
  // private ParticleSystem m_DeathExplosion;
  //
  // [SerializeField]
  // private float m_HealthPillDropRate;
  //
  // [SerializeField]
  // private GameObject m_HealthPill;

  // [SerializeField]
  // private float m_DoublePointsDropRate;
  //
  // [SerializeField]
  // private GameObject m_DoublePoints;

  [SerializeField]
  private int m_Score;
  #endregion

  // #region Private Variables
  // private float p_curHealth;
  // #endregion

  #region Cached Components
  private Rigidbody cc_Rb;
  #endregion

  #region Cached Region
  private Transform cr_Player;
  #endregion

  #region Initalization
  private void Awake() {
      // p_curHealth = m_MaxHealth;

      cc_Rb = GetComponent<Rigidbody>();
  }

  private void Start() {
      cr_Player = FindObjectOfType<PlayerController>().transform;
  }
  #endregion

  #region Main Update
  private void FixedUpdate() {
      Vector3 dir = new Vector3(0,0,-1);
      // Vector3 dir = transform.position;
      // dir.Normalize();
      cc_Rb.MovePosition(cc_Rb.position + dir * m_Speed * Time.fixedDeltaTime);
  }
  #endregion

  #region Collision Methods
  private void OnCollisionEnter(Collision collision) {
      GameObject other = collision.collider.gameObject;
      if (other.CompareTag("Player")) {
          Destroy(gameObject); // not sure when to destroy enemy
          other.GetComponent<PlayerController>().DecreaseHealth(m_Damage);
      }
  }
  #endregion

  // #region Health Methods
  // public void Collide() {
      // p_curHealth -= amount;
      // if (p_curHealth <= 0)
      // {
      //     ScoreManager.singleton.IncreaseScore(m_Score);
      //     if (Random.value < m_HealthPillDropRate)
      //     {
      //         Instantiate(m_HealthPill, transform.position, Quaternion.identity);
      //     } else if (Random.value < m_DoublePointsDropRate)
      //     {
      //         Instantiate(m_DoublePoints, transform.position, Quaternion.identity);
      //     }
      //     Instantiate(m_DeathExplosion, transform.position, Quaternion.identity);
      //     Destroy(gameObject);
      // }
  //     Destroy(gameObject);
  // }
  // #endregion
}
