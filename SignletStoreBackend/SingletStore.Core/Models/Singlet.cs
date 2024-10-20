using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletStore.Core.Models
{
    public class Singlet
    {
        public const int MAX_TITLE_LENGTH = 250;
        private Singlet(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get;} = string.Empty;
        public decimal Price { get;}
        public static (Singlet Singlet, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "Title can not be empty or longer then 250 symbols";
            }

            Singlet singlet = new Singlet(id, title, description, price);

            return (singlet, error);
        }

    }
}
