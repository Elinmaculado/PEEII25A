using UnityEngine;

public class ShaderControl : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _material;
    [SerializeField] private Color _color;
    [SerializeField] private string _propertyName = "_MainColor";
    [SerializeField] private string _globalName = "_SecondaryColor";

    [SerializeField] private ModifyMaterialTypes _modifyMaterialTypes;
    
    private MaterialPropertyBlock _propertyBlock;
    public enum ModifyMaterialTypes
    {
        Instance,
        Material,
        SharedMaterial,
        PropertyBlock,
        Global
    }
    void Start()
    {
        _propertyBlock = new MaterialPropertyBlock();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (_modifyMaterialTypes)
            {
                // Crea una copia de la instancia del material en memoria.
                case ModifyMaterialTypes.Instance:
                {
                    //_renderer.material.color = _color; //Solo funciona con propiedad _MainColor
                    //_renderer.material.SetColor(_propertyName, _color); //Flexible para cualquier propiedad de color
                    _renderer.material.SetColor(_propertyName, Color.HSVToRGB(Random.value, 1, 1));   
                } break;
                // Modifica el material directamente, afectando a todos los objetos que lo usan.
                case ModifyMaterialTypes.Material:
                {
                    _material.SetColor(_propertyName, Color.HSVToRGB(Random.value, 1, 1));
                }break;
                // Modifica el material compartido, afectando a todos los objetos que usan este material.
                case ModifyMaterialTypes.SharedMaterial:
                {
                    _renderer.sharedMaterial.SetColor(_propertyName, Color.HSVToRGB(Random.value, 1, 1));
                } break;
                // Modifica el MaterialPropertyBlock, afectando solo al objeto actual.
                case ModifyMaterialTypes.PropertyBlock:
                {
                    _propertyBlock.SetColor(_propertyName, Color.HSVToRGB(Random.value, 1, 1));
                    _renderer.SetPropertyBlock(_propertyBlock);
                } break;
                // Modifica una propiedad global, afectando a todos los objetos que usan esta propiedad.
                case ModifyMaterialTypes.Global:
                {
                    Shader.SetGlobalColor(_globalName, Color.HSVToRGB(Random.value, 1, 1));
                } break;
                default: Debug.LogWarning("ModifyMaterialTypes not implemented: " + _modifyMaterialTypes); break;
            }
        }
    }
}
