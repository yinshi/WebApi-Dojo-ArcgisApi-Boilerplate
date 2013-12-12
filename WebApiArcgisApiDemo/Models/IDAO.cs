using System.Collections.Generic;

namespace WebApiArcgisApiDemo.Models
{
    public interface IDAO
    {
        List<object> GetTable(string queryKey, List<string> parameterList = null);
    }
}
