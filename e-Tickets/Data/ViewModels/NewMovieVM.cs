using e_Tickets.Data;
using e_Tickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Tickets.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name="Movie Name")]
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Display(Name = "Price in Rp")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }

        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster URL is Required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "End Date is Required")]
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is Required")]
        public List<int> ActorIds { get; set; }

        //Cinema
        [Display(Name = "Select cinema")]
        [Required(ErrorMessage = "Movie cinema is Required")]
        public int CinemaId { get; set; }

        //Producer
        [Display(Name = "Select producer")]
        [Required(ErrorMessage = "Movie producer is Required")]
        public int ProducerId { get; set; }
    }
}
