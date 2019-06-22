using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movie_api.Models
{
    public class Rating
    {
       [StringLength(255)] 
       public string Source { get; set; }
       [StringLength(255)]
       public string Value { get; set; }
    }
    public class MovieModel
    {
        [StringLength(255)] 
        public string Title { get; set; }
        [StringLength(4)] 
        public string Year { get; set; }
        [StringLength(10)] 
        
        public string Rated { get; set; }
        [StringLength(11)] 
        public string Released { get; set; }
        [StringLength(20)] 
        public string Runtime { get; set; }
        [StringLength(255)] 
        public string Genre { get; set; }
        [StringLength(50)] 
        public string Director { get; set; }
        [StringLength(10000)] 
        public string Writer { get; set; }
        [StringLength(1000)] 
        public string Actors { get; set; }
        [StringLength(10000)] 
        public string Plot { get; set; }
        [StringLength(50)] 
        public string Language { get; set; }
        [StringLength(255)] 
        public string Country { get; set; }
        [StringLength(1000)] 
        public string Awards { get; set; }
        [StringLength(1000)] 
        public string Poster { get; set; }
        public List<Rating> Ratings { get; set; }
        [StringLength(20)] 
        public string Metascore { get; set; }
        [StringLength(3)] 
        public string ImdbRating { get; set; }
        [StringLength(50)] 
        public string ImdbVotes { get; set; }
        [StringLength(10)] 
        public string ImdbID { get; set; }
        [StringLength(50)] 
        public string Type { get; set; }
        [StringLength(11)] 
        public string DVD { get; set; }
        [StringLength(50)] 
        public string BoxOffice { get; set; }
        [StringLength(255)] 
        public string Production { get; set; }
        [StringLength(255)] 
        public string Website { get; set; }
        [StringLength(5)] 
        public string Response { get; set; }
    }
}