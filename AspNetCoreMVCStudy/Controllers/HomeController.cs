using AspNetCoreMVCStudy.DB;
using AspNetCoreMVCStudy.DB.Entities;
using AspNetCoreMVCStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspNetCoreMVCStudy.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ApplicationDbContext _applicationDbContext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
    {
        _logger = logger;

        // https://learn.microsoft.com/ja-jp/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#create-controller-and-views
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IActionResult> Index()
    {
        var model = new HomeModel();

        model.Books = await _applicationDbContext.Books
            .GroupJoin(
                _applicationDbContext.Authors,
                book => book.AuthorId,
                author => author.AuthorId,
                (book, author) => new { book, author }
            )
            .SelectMany(
                bookAndAuthor => bookAndAuthor.author.DefaultIfEmpty(),
                (bookAndAuthor, author) =>
                new Book()
                {
                    BookId = bookAndAuthor.book.BookId,
                    Title = bookAndAuthor.book.Title,
                    AuthorId = bookAndAuthor.book.AuthorId,
                    Author = author
                }
            )
            .ToListAsync();

        return View(model);
    }

    public async Task<IActionResult> Search(HomeModel model)
    {
        // Where 以外は Index() メソッドと同じ。
        model.Books = await _applicationDbContext.Books
            .GroupJoin(
                _applicationDbContext.Authors,
                book => book.AuthorId,
                author => author.AuthorId,
                (book, author) => new { book, author }
            )
            .SelectMany(
                bookAndAuthor => bookAndAuthor.author.DefaultIfEmpty(),
                (bookAndAuthor, author) =>
                new Book()
                {
                    BookId = bookAndAuthor.book.BookId,
                    Title = bookAndAuthor.book.Title,
                    AuthorId = bookAndAuthor.book.AuthorId,
                    Author = author
                }
            )
            .Where(book => book.Title.Contains(model.SearchTitle))
            .ToListAsync();

        return View(nameof(HomeController.Index), model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}