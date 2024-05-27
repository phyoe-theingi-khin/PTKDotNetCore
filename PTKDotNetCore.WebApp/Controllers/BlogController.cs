﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using PTKDotNetCore.WebApp.Models;

namespace PTKDotNetCore.WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly AppDbContext _db; 
    public BlogController() {
        _db = new AppDbContext();

    }
    [HttpGet]
    public IActionResult GetBlogs()
    {
        List<BlogModel>lst=_db.Blogs.OrderByDescending(x=>x.BlogId).ToList();
        return Ok(lst);
    }
    [HttpGet("{id}")]
    public IActionResult GetBlog(int id)
    {
        BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
        if (item is null)
        {
            return NotFound("No data found.");
        }

        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateBlogs(BlogModel blog)
    {
        _db.Blogs.Add(blog);
        int result= _db.SaveChanges();
        string message = result > 0 ? "saving successful." : "saving failed.";
        return Ok(message);
    }
    [HttpPut("{id}") ]
    public IActionResult UpdateBlogs(int id,BlogModel blog)
    {
        BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
        if (item is null)
        {
            return NotFound("No data found.");
        }

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;
        int result = _db.SaveChanges();

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        return Ok(message);
    }
    [HttpDelete ("{id}")]
    public IActionResult DeleteBlogs(int id)
    {
        BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
        if (item is null)
        {
            return NotFound("No data found.");
        }

        _db.Blogs.Remove(item);
        int result = _db.SaveChanges();

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        return Ok(message);
    }
}