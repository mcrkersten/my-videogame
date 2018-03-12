using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAmount : MonoBehaviour
{
    [Header("Damage atributes")]
    [SerializeField, Tooltip("Damage to player on one hit")]
    public int DamageToPlayer;
    public float force;
}
