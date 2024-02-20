using Microsoft.EntityFrameworkCore;
using Prog240208;
using System.Linq;
using System.Numerics;

DB dB = new DB();

AddUserNew("user", "password");
AddUserNew("user2", "password2");

AddBlogNew("Blog1");
AddBlogNew("Blog2");

AddCategoryNew("fantasy");
AddCategoryNew("fiction");
AddCategoryNew("sci-fi");

AddArticleNew("Article",
                    dB.Blogs.Where(b => b.Name == "Blog1").First(),
                    dB.Users.Where(u => u.Name == "user").First(),
                    new List<Category>());

dB.Articles.Where(u => u.Title == "Article").First().Categories.
                    Add(dB.Categories.Where(c => c.Name == "fantasy").First());
dB.SaveChanges();

dB.Articles.Where(u => u.Title == "Article").First().Categories.
                    Add(dB.Categories.Where(c => c.Name == "fiction").First());
dB.SaveChanges();

AddArticleNew("Article2",
                   dB.Blogs.Where(b => b.Name == "Blog2").First(),
                   dB.Users.Where(u => u.Name == "user2").First(),
                   new List<Category>());

dB.Articles.Where(u => u.Title == "Article2").First().Categories.
                    Add(dB.Categories.Where(c => c.Name == "fantasy").First());
dB.SaveChanges();

dB.Articles.Where(u => u.Title == "Article2").First().Categories.
                   Add(dB.Categories.Where(c => c.Name == "fiction").First());
dB.SaveChanges();

AddArticleNew("Article3",
                   dB.Blogs.Where(b => b.Name == "Blog2").First(),
                   dB.Users.Where(u => u.Name == "user2").First(),
                   new List<Category>());

dB.Articles.Where(u => u.Title == "Article3").First().Categories.
                    Add(dB.Categories.Where(c => c.Name == "sci-fi").First());
dB.SaveChanges();

dB.Articles.Where(u => u.Title == "Article3").First().Categories.
                    Add(dB.Categories.Where(c => c.Name == "fiction").First());
dB.SaveChanges();

dB.Users.Where(u => u.Name == "user").First().Articles.
                Add(dB.Articles.Where(a => a.Title == "Article").First());
dB.SaveChanges();

dB.Users.Where(u => u.Name == "user2").First().Articles.
                Add(dB.Articles.Where(a => a.Title == "Article2").First());
dB.SaveChanges();

dB.Users.Where(u => u.Name == "user2").First().Articles.
                Add(dB.Articles.Where(a => a.Title == "Article3").First());
dB.SaveChanges();

void AddUserNew(string name, string password)
{
    dB.Users.Add(new User { Name = name, Password = password });
    dB.SaveChanges();
}

void AddBlogNew(string name)
{
    dB.Blogs.Add(new Blog { Name = name });
    dB.SaveChanges();
}

void AddArticleNew(string title, Blog blog, User user, List<Category> categories)
{
    dB.Articles.Add(new Article { Title = title, Blog = blog, User = user, Categories = categories });
    dB.SaveChanges();
}

void AddCategoryNew(string name)
{
    dB.Categories.Add(new Category { Name = name });
    dB.SaveChanges();
}

Console.WriteLine(dB.Articles.First().Blog.Articles.First().User.Articles.First().Categories.First().Articles.First().Title);