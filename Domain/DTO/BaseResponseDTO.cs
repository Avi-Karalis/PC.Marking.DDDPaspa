namespace Domain.DTO;


/// <summary>
/// Helper DTO for controllers returns
/// </summary>
public partial class BaseResponseDTO
{
    public bool IsSuccess { get; set; }
    public string[]? Errors { get; set; }
}

public partial class BaseResponseDTO<TResponse>
{
    public bool IsSuccess { get; set; }
    public TResponse? Response { get; set; }
    public string[]? Errors { get; set; }
}

