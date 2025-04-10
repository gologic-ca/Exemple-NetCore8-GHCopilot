using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Conduit.Domain;

public class Person
{
    [JsonIgnore]
    public int PersonId { get; init; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Bio { get; set; }

    public string? Image { get; set; }

    [JsonIgnore]
    public List<ArticleFavorite> ArticleFavorites { get; init; } = [];

    [JsonIgnore]
    public List<FollowedPeople> Following { get; init; } = [];

    [JsonIgnore]
    public List<FollowedPeople> Followers { get; init; } = [];

    [JsonIgnore]
    public byte[] Hash { get; set; } = [];

    [JsonIgnore]
    public byte[] Salt { get; set; } = [];
}
