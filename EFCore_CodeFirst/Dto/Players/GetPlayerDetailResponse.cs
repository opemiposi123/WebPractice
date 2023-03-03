using EFCore_CodeFirst.Dto.PlayerInstruments;

namespace EFCore_CodeFirst.Dto.Players
{
    public class GetPlayerDetailResponse
    {
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public List<GetPlayerInstrumentResponse> PlayerInstruments
        { get; set; }
    }
}
