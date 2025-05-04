using System;
using UnityEngine;

public class FireballAttackHandler : MonoBehaviour, IAttackHandler
{
    public GameObject fireball;
    public Transform firePoint;
    public float fireballSpeed = 10f;
    public float lifeTime = 5f;

    private EnemyController _enemy;

    private void Awake()
    {
        _enemy = GetComponent<EnemyController>();
    }

    public void PerformAttack()
    {
        Vector2 direction = (_enemy.player.position - firePoint.position).normalized;
        GameObject fireball = Instantiate(this.fireball, firePoint.position, Quaternion.identity);
        Fireball projectile = fireball.GetComponent<Fireball>();
        projectile?.Initialize(direction);
    }
}
