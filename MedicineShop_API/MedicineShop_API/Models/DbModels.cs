using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicineShop_API.Models
{
    public class GenericGroup
    {
        public GenericGroup()
        {
            this.Medicines = new List<Medicine>();
        }
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string GroupName { get; set; }
        [Required, StringLength(30)]
        public string ShelfCode { get; set; }

        //Navigation
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
    public class Medicine
    {
        public int MedicineId { get; set; }
        [Required, StringLength(50)]
        public string MedicineName { get; set; }

        [Required, ForeignKey("GenericGroup")]
        public int GenericGroupId { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime ExpiryDate { get; set; }

        [Required, Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [StringLength(200)]
        public string ImagePath { get; set; }

        //Navigation
        public virtual GenericGroup GenericGroup { get; set; }
    }
    public class MedicineDbContext : DbContext
    {
        public MedicineDbContext(DbContextOptions<MedicineDbContext> options) : base(options)
        {

        }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<GenericGroup> GenericGroups { get; set; }
    }
}
