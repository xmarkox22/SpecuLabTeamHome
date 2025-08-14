namespace PrototipoApi.Application.Common
{
    public record PageResult<T>(List<T> Items, int Total, int Page, int Size);
}
