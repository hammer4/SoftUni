namespace Entity_Framework_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int PostId { get; set; }

        public int? AuthorId { get; set; }

        [StringLength(100)]
        public string AuthorName { get; set; }

        public DateTime Date { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
