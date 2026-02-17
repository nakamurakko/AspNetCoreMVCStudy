using AspNetCoreMVCStudy.DB.Entities;

namespace AspNetCoreMVCStudy.Models;

public class HomeModel
{

    public IList<Book> Books { get; set; } = new List<Book>();

    public string SearchTitle { get; set; } = "";

}
