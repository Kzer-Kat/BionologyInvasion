using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("Stats")]
    public int damage = 1;
    public float lifeTime = 3f;

    private void Start()
    {
        // Destruir la bala autom�ticamente despu�s de cierto tiempo
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ignorar colisiones con el jugador, otras balas del jugador o columnas
        if (other.CompareTag("Player") || other.CompareTag("PlayerBullet") || other.CompareTag("Columna") || other.CompareTag("EnemyBullet") || other.CompareTag("PickUpWeapon"))
            return;

        // Si impacta un enemigo, aplicar da�o
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
            return;
        }

        // Si toca cualquier otra cosa (pared, l�mite, etc.)
        Destroy(gameObject);
    }
}
