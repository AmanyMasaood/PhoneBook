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

        // GET api/<controller>/id/pram/value
        [HttpGet("{UserId}/{Param}/{Value}")]
        public List<PhoneBook> Get(string UserId,string param,string value)
        {
            List<PhoneBook> list = (from c in context.PhoneBook
                                    where c.UserID == UserId
                                    select c).ToList();
            var property = new PhoneBook().GetType().GetProperty(param);
            if (property != null)
            {
                list=list.Where(x => property.GetValue(x).ToString() == value).ToList();
                //list = list.Where(x => x.PhoneBookID == value).ToList();
                return list;
            }
            else
                return null;
        }

        // GET api/<controller>/id
        [HttpGet("{UserId}")]
        public List<PhoneBook> Get(string UserId)
        {
            List<PhoneBook> list = (from c in context.PhoneBook
                                    where c.UserID==UserId
                                    select c).ToList();

            return list;
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
