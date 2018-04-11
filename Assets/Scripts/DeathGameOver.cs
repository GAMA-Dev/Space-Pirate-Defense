using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGameOver : MonoBehaviour, IDeathMethod {
    public void Die()
    {
        Debug.Log("Game Over");
    }
}
