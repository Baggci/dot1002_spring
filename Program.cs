
// --- SET 1 ---

// Exercise 1
public enum ResourceType { Gold, Crystal, Food, Wood, Iron }
public Dictionary<ResourceType, Text> resourceTexts;

void UpdateResource(ResourceType type, int amount) 
{
    if (resourceTexts.TryGetValue(type, out Text textComponent)) 
    {
        textComponent.text = $"Amount: {amount}";
    }
}

// Exercise 2
private AudioSource audioSource;

void Start() 
{
    audioSource = GetComponent<AudioSource>();
}

void PlaySound(AudioClip clip) 
{
    audioSource.PlayOneShot(clip);
}

void Jump() 
{
    PlaySound(jumpSound);
    rb.velocity = Vector2.up * jumpForce;
}

void Shoot() 
{
    PlaySound(shootSound);
    Instantiate(bullet);
}

// Exercise 3
void ApplyDamage(int amount) 
{
    health = Mathf.Max(health - amount, 0);
    Debug.Log($"Health: {health}");
}

void TakePhysicalDamage(int amount) => ApplyDamage(amount);
void TakeMagicDamage(int amount) => ApplyDamage(amount);

// Exercise 4
void SpawnEntity(GameObject prefab) 
{
    Vector3 spawnPos = transform.position + new Vector3(0, 1, 0);
    Instantiate(prefab, spawnPos, Quaternion.identity);
    PlaySpawnParticle(spawnPos);
}

void SpawnGoblin() => SpawnEntity(goblinPrefab);
void SpawnOrc() => SpawnEntity(orcPrefab);

// Exercise 5
public float mapBoundaryX = 100f;

void Move(Vector3 direction) 
{
    Vector3 newPos = transform.position + (direction * speed * Time.deltaTime);
    newPos.x = Mathf.Clamp(newPos.x, -mapBoundaryX, mapBoundaryX);
    transform.position = newPos;
}

void MoveRight() => Move(Vector3.right);
void MoveLeft() => Move(Vector3.left);

// --- SET 2 ---

// Exercise 1
public class HealthPotion 
{
    public int healAmount = 10;

    public void Consume(Player player) 
    {
        player.Heal(healAmount);
    }
}

// Exercise 2
public class CollectibleDot 
{
    public int pointValue = 10;

    public void Collect(Player player) 
    {
        player.AddScore(pointValue);
    }
}

// Exercise 3
public class Spaceship 
{
    public float moveSpeed = 5f;

    public void MoveHorizontal(float input) 
    {
        transform.Translate(Vector3.right * input * moveSpeed * Time.deltaTime);
    }
}

// Exercise 4
public class PlayerStats 
{
    public float jumpForce = 5f;
}

// Exercise 5
public interface IWeapon 
{
    void Fire();
}

public class Pistol : IWeapon 
{
    public void Fire() 
    {
        // Fire logic
    }
}

// --- SET 3 ---

// Exercise 1
public bool IsDead => health <= 0;

// Exercise 2
List<int> startingLevels = new List<int> { 1, 2, 3 };

// Exercise 3
public enum EnemyType { Goblin, Orc, Troll }

void CheckEnemy(EnemyType enemyType) 
{
    switch (enemyType) 
    {
        case EnemyType.Goblin:
        case EnemyType.Orc:
        case EnemyType.Troll:
            Attack();
            break;
        default:
            RunAway();
            break;
    }
}

// Exercise 4
public float cooldownDuration = 5f;
private float timer = 0f;
public bool isCooldown = true;

void Update() 
{
    if (isCooldown) 
    {
        timer += Time.deltaTime;
        if (timer >= cooldownDuration) 
        {
            isCooldown = false;
            timer = 0f;
        }
    }
}

// Exercise 5
int GetHighestScore(int score1, int score2) => System.Math.Max(score1, score2);