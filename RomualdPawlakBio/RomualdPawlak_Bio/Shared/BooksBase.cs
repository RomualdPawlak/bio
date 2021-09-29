﻿using Microsoft.AspNetCore.Components;
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

        protected override async Task OnInitializedAsync()
        {
            _books = (await Http.GetFromJsonAsync<Book[]>("data/books.json"))
                .OrderByDescending(x => x.PublishDate)
                .ToList();
        }
    }
}
