using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessAccessLayer.BusinessObjects
{
    public class CustomMovie
    {
        public Movie Movie { get; set; }    

        public Video Video { get; set; }

        public List<Comment> Comments { get; set; } 

        public List<Genre> Genres { get; set; }

        public Rate Rate { get; set; }


        private int GetAverageRate()
        {
            
        }
    }
}
