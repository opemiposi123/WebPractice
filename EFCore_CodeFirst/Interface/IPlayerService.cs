using EFCore_CodeFirst.Dto;
using EFCore_CodeFirst.Dto.Players;

namespace EFCore_CodeFirst.Interface
{
    public interface IPlayerService
    {
        Task CreatePlayerAsync(CreatePlayerRequest playerRequest);
        Task<PagedResponse<GetPlayerResponse>> GetPlayersAsync(UrlQueryParameters urlQueryParameters);
        Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id);
        Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest);
        Task<bool> DeletePlayerAsync(int id);
    }
}
