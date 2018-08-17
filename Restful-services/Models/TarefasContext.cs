using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restful_services.Models
{
    public class TarefasContext : DbContext
    {
        public DbSet<Tarefas> Tarefas { get; set; }
    }
}