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

        // GET api/<controller>/id
        [HttpGet"{id}"]
        public List<PhoneBook> Get( string id)
        {
            List<PhoneBook> list = (from c in context.PhoneBooks
                                where c.PhoneBookID==id
                               select c).ToList();
            
            if(list!=null)
            return list.FirstOrDefault() ;
            else 
            return null;
        }
        
        // GET api/<controller>
        [HttpGet]
        public List<PhoneBook> Get()
        {
            List<PhoneBook> list = (from c in context.PhoneBooks
                               select c).ToList();

            return list ;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(PhoneBook book)
        {
            if (book != null)
            {
                if (context.PhoneBooks.Contains(book))
                {
                    PhoneBook item = context.PhoneBooks.Find(book);
                    item.BookName = book.BookName;
                    item.Comment = book.Comment;

                    context.SaveChangesAsync();
                }
                else
                {
                    context.PhoneBooks.Add(book);
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
                context.PhoneBooks.Remove(book);
                context.SaveChangesAsync();
            }
        }
    }
}
