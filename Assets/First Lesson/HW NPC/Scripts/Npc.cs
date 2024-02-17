using UnityEngine;

public class Npc : MonoBehaviour
{
    private INpcBehavior _npcBehavior;
    private int _level;

    private void Start()
    {
        SetBehavior(new SillyNpc());
    }

    public void DescribeProducts()
    {
        string products = _npcBehavior.GetProducts();
        if (products != null)
        {
            Debug.Log("Интересно что я продаю? Тогда слушай: " + products);
            return;
        }

        Debug.Log("У меня ничего нету!");
    }

    public void IncreaseLevel()
    {
        if (_level == 2)
        {
            Debug.Log("NPC уже прокачен на максимум!");
            return;
        }
        Debug.Log("Npc прокачен!");

        _level++;

        switch (_level)
        {
            case 1:
                SetBehavior(new FruitVendorNpc()); break;
            case 2:
                SetBehavior(new ArmorerNpc()); break;
        }
    }

    private void SetBehavior(INpcBehavior behavior) => _npcBehavior = behavior;
}
