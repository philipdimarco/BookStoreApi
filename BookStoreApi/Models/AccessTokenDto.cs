namespace BookStoreApi.Models
{
    public class AccessTokenDto
    {
        public string AccessToken { get; init; }

        public AccessTokenDto(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
