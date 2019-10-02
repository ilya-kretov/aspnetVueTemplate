using System;
using System.Collections.Generic;
using System.Linq;
using aspnetVue.Models;

namespace aspnetVue.Providers
{
    public class ListMatchProvider : IListMatchProvider
    {
        private readonly string[] _summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private List<ListMatchRow> ListMatches { get; set; }

        public ListMatchProvider()
        {
            Initialize(50);
        }

        private void Initialize(int quantity)
        {
            var rng = new Random();
            ListMatches = Enumerable.Range(1, quantity).Select(index => new ListMatchRow
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = _summaries[rng.Next(_summaries.Length)]
            }).ToList();
        }

        public List<ListMatchRow> GetRows()
        {
            return ListMatches;
        }
    }
}
