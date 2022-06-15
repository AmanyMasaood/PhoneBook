using System;
using System.Collections.Generic;
using System.Linq;
using Informatic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Informatic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        PhoneBookDBContext context;
        public PhoneBookController(PhoneBookDBContext _context)
        {
            context = _context;

        }

        // GET api/<controller>
        [HttpGet]
        public List<PhoneBook> Get()
        {
            List<PhoneBook> list = (from c in context.PhoneBook
                               select c).ToList();

            return list ;
        }

        // GET api/<controller>/id
        [HttpGet("{UserId}")]
        public PhoneBook Get(string UserId)
        {
            List<PhoneBook> list = (from c in context.PhoneBook
                                    where c.UserID==UserId
                                    select c).ToList();

            if (list != null)
                return list.FirstOrDefault();
            else
                return null;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(PhoneBook book)
        {
            if (book != null)
            {
                if (context.PhoneBook.Contains(book))
                {
                    PhoneBook item = context.PhoneBook.Find(book);
                    item.BookName = book.BookName;
                    item.Comment = book.Comment;

                    context.SaveChangesAsync();
                }
                else
                {
                    context.PhoneBook.Add(book);
                    context.SaveChangesAsync();
                }
            }
        }

        // POST api/<controller>
        [HttpDelete]
        public void delete(PhoneBook book)
        {
            if (book != null)
            {
                context.PhoneBook.Remove(book);
                context.SaveChangesAsync();
            }
        }
    }
}
