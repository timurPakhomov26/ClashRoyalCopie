using UnityEngine;

[CreateAssetMenu(menuName = "Hero/New Hero")]
public class MobInfo : ScriptableObject
{
    [SerializeField] private int _manaCost;
    public int ManaCost => _manaCost;
    [SerializeField] private string _name;
    public string Name => _name;
    
    [SerializeField] private Sprite _sprite;
    public Sprite MobSprite => _sprite;

    [SerializeField] private float _damage;
    public float Damage => _damage;
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;

    [SerializeField] private float _damagePerSecond;
    public float DamagePerSecond => _damagePerSecond;

    [SerializeField] private GoatOfMob _goat;
    public GoatOfMob Goat => _goat;


}

public enum GoatOfMob
{
    All,
    OnlyBuildings
}
