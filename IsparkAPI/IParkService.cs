namespace IsparkAPI
{
    public interface IParkService
    {
        Task<IEnumerable<ParkListDto>> GetListAsync();
        Task<ParkDetailDto?> GetDetailAsync(int id);
    }
}
