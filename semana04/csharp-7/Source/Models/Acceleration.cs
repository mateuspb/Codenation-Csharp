using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, MaxLength(100), Column("name")]
        public string Name { get; set; }

        [Required, MaxLength(50), Column("slug")]
        public string Slug { get; set; }

        [Required, Column("challenge_id")]
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }

        [Required, Column("created_at")]
        public DateTime Created_at { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
    }
}