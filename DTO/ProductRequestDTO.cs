using System;

namespace provide_webapi.DTO;

public sealed class ProductRequestDTO
{
    public ProductRequestDTO(string base64Image)
    {
        Base64Image = base64Image;
    }
    public string Base64Image { get; }
}
