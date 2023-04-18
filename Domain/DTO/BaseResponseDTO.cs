namespace Domain.DTO;


/// <summary>
/// Helper DTO for controllers retuns
/// </summary>
public class BaseResponseDTO
{
    public bool IsSuccess { get; set; }
    public string[] Errors { get; set; }
}

