using System.Collections.Generic;
using aspnetVue.Models;

namespace aspnetVue.Providers
{
    public interface IListMatchProvider
    {
        List<ListMatchRow> GetRows();
    }
}
