using System;

namespace provide_webapi.DTO;

public sealed class QRCodeResponseDTO
{

    public QRCodeResponseDTO(byte[] bytes, string uri)
    {
        Bytes = Convert.ToBase64String(bytes);
        Uri = uri;
    }

    public string Bytes { get; }
    public string Uri { get; }
}
