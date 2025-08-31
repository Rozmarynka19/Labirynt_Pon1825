using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;
    public Material mat1, mat2;

    private void ColorTheChildren()
    {
        foreach(Transform child in transform)
        {
            if (child.tag == "Wall")
            {
                if (Random.Range(1,100) % 3 == 0)
                    child.gameObject.GetComponent<Renderer>().material = mat1;
                else
                    child.gameObject.GetComponent<Renderer>().material = mat2;
            }
        }
    }

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
    public void GenerateLabirynth()
    {
        for(int x=0; x<map.width; x++)
        {
            for(int z=0; z<map.height; z++)
            {
                GenerateTile(x, z);
            }
        }

        ColorTheChildren();
    }
}
