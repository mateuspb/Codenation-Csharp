using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("challenge")]
    public class Challenge
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("slug")]
        public string Slug { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime Created_at { get; set; }

        public List<Acceleration> Accelerations { get; set; }

        public List<Submission> Submissions { get; set; }
    }
}