
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewFile",menuName ="Items/Shirt")]
public class ShirtData : ScriptableObject
{
    [SerializeField] public int shirtId;
    [SerializeField] public string namee;
    [SerializeField] public int price;
    [SerializeField] public MeshFilter shirtMesh;
    [SerializeField] public Material shirtMaterial;
    [SerializeField] public Sprite shirtIcon;

}
