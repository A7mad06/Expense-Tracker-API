namespace Shared
{
    public record UserResultDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; init; } = null!;
    }
}
