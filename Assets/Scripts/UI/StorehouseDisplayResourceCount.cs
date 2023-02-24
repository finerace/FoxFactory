using TMPro;
using UnityEngine;

public class StorehouseDisplayResourceCount : MonoBehaviour
{
    [SerializeField] private Storehouse storehouse;
    [SerializeField] private TMP_Text resourceCountLabel;

    private void Start()
    {
        storehouse.OnBlicnhikiCountChangeEvent += UpdateResourceCount;
    }

    private void UpdateResourceCount(int currentResourceCount)
    {
        resourceCountLabel.text = $"{currentResourceCount}/{storehouse.MaxResourceCount}";
    }

}
