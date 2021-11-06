using Microsoft.AspNetCore.Components;
using RomualdPawlak_Bio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RomualdPawlak_Bio.Shared
{
    public class BooksBase : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        protected IList<Book> _books { get; set; }
        protected IList<Book> BooksToBeRendered { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _books = (await Http.GetFromJsonAsync<Book[]>("data/books.json")).ToList();

            PrepareDefaultBookSet();
        }

        private void PrepareDefaultBookSet()
        {
            BooksToBeRendered = FilterBooks();
        }

        protected void ShowAll()
        {
            PrepareDefaultBookSet();
        }

        protected void ShowAdultBooks()
        {
            BooksToBeRendered = FilterBooks()
                .Where(x => x.Category == BookCategory.Adult)
                .ToList();
        }

        protected void ShowKidBooks()
        {
            BooksToBeRendered = FilterBooks()
                .Where(x => x.Category == BookCategory.Kids)
                .ToList();
        }

        protected void ShowAnthologies() 
        {
            BooksToBeRendered = FilterBooks()
                .Where(x => x.Category == BookCategory.Anthology)
                .ToList();
        }

        private IList<Book> FilterBooks()
        {
            return _books
                .Where(x => !string.IsNullOrWhiteSpace(x.CoverMini))
                .OrderByDescending(x => x.PublishDate)
                .ToList();
        }
    }
}
