﻿using ConsoleApp1.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.MvcApp.Controllers
{
    //https://localhost:7047/Blog/Index
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController()
        {
            _context = new AppDbContext();
        }
        [ActionName("Index")]
    
        public IActionResult BlogIndex()
        {
            List<BlogModel> lst = _context.Blogs.ToList();
            return View("BlogIndex",lst);
        }
        [ActionName ("Edit")]
        public IActionResult BlogEdit(int id)
        {
           BlogModel? item= _context.Blogs.FirstOrDefault(x => x.BlogId == id);
          if(item is null) 
            {
                return Redirect("/Blog");
            }
          return View("BlogEdit",item);
        }
        [ActionName ("Create")]
       //string title,string author,string content
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");

        }
        [HttpPost]
        [ActionName ("Save")]
        public IActionResult BlogSave(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return Redirect("/Blog");
        }
        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id,BlogModel blog)
        {
            BlogModel? item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor= blog.BlogAuthor;   
            item.BlogContent= blog.BlogContent;
            _context.SaveChanges();
            return Redirect("/Blog");
        }
        [ActionName("Delete")]
        public IActionResult BlogDelete(int id)
        {
            BlogModel? item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }
            _context.Blogs.Remove(item);
            _context.SaveChanges();
            return Redirect("/Blog");
        }
    }
}
