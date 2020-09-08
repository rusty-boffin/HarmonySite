using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    public interface IConnection
    {
        Task<Dictionary<int, Dictionary<string, string>>> QueryAsync(string table, string filter, int id);

        Dictionary<int, Dictionary<string, string>> Query(string table, string filter, int id);

    }

}
