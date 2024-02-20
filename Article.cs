using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog240208
{
    public class Article
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();

        public int BlogId {  get; set; }
        public Blog Blog { get; set; }
        public User User { get; set; }
    }
}
