using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDSystem : MonoBehaviour
{
    [SerializeField] private bool isMaser = false;
    [SerializeField] private float MaxHealth = 100;
    public float CurrentHealth; //Фиксить блять!!! Нехуй пабликами бросаться
    [SerializeField] private float Damage = 35;

    void Awake()
    {
        CurrentHealth = MaxHealth;
    }
    
    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;

        if (CurrentHealth <= 0)
        {     
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Untagged")) //Ну это тоже хуета так-то
            return;
        if(other.gameObject.GetComponent<HDSystem>().isMaser == false && isMaser == false)
            return;
        other.gameObject.GetComponent<HDSystem>().TakeDamage(Damage);
    }
}
