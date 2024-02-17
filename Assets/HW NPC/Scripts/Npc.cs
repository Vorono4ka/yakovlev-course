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
            Debug.Log("��������� ��� � ������? ����� ������: " + products);
            return;
        }

        Debug.Log("� ���� ������ ����!");
    }

    public void IncreaseLevel()
    {
        if (_level == 2)
        {
            Debug.Log("NPC ��� �������� �� ��������!");
            return;
        }
        Debug.Log("Npc ��������!");

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
