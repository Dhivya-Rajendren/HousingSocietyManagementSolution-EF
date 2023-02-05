using System.ComponentModel.DataAnnotations;

namespace HousingSociety.Domain
{
    public class Flat
    {
        [Key]
        public int FlatNo { get; set; }

        //Default conventions

        //The datatype of column by default is nvarchar(max)
        public string FlatName { get; set; }
        public string FlatOwner { get; set; }

        //The datatype of column is bigint
        public long? AAdhar { get; set; }

        public long Contact { get; set; }

        public string Wing { get; set; }

        public string? Email { get; set; }

        public bool IsActive { get; set; }





    }
}