using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : SeraphLibrary
{
    public string itemName;
    private int itemID;
    [SerializeField]
    private int _basePrice;
    private SpriteRenderer _itemSR;
    [SerializeField]
    private ItemType _itemType;
    [SerializeField]
    private WeaponBase _weaponScript;
    private Collider2D _collider;
    [SerializeField]
    private bool _equipped;
    [SerializeField]
    private bool _dropped;


    // Start is called before the first frame update
    public virtual void Start()
    {
        _itemSR = GetComponent<SpriteRenderer>();
        _weaponScript = GetComponent<WeaponBase>();
        _collider = GetComponent<Collider2D>();
    }

    public virtual void Use()
    {

    }

    public virtual void OnPickup()
    {

    }
    public virtual void OnDrop()
    {

    }

    public virtual void UpdateItemState()
    {

    }

    public virtual int Price(int priceMod)
    {
        int processedPrice = (_basePrice * priceMod);
        return processedPrice;
    }
}
