using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0)
        {
            Debug.LogWarning($"Pixel ({x},{z}) jest przezroczysty!");
            return;
        }

        foreach(ColorToPrefab mapping in colorMappings)
        {
            if (mapping.color.Equals(pixelColor))
            {
                Vector3 pos = new Vector3(x, 0, z) * offset;
                Instantiate(mapping.prefab, pos, Quaternion.identity, transform);
            }
        }
    }
}
