using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StageOne.Models
{
    public class UserComment
    {
        public int ID { get; set; }
        string whatTheyWrote { get; set; }
        int whoWroteIt { get; set; }

    }

    public class UserCommentDBContext : DbContext
    {
        public DbSet<UserComment> UserComments { get; set; }
    }
}