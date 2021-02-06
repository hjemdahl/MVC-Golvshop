using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Golvshop.Models
{
    public class OrderModel
    {
        //Properties
        [Display(Name = "Golv")]
        public string Floor { get; set; }

        [Display(Name = "Pris(kr/kvm)")]
        public int PriceKvm { get; set; }

        public int Kvm { get; set; }

        [Display(Name = "Total pris(kr)")]
        public int TotalPrice { get; set; }

        [Range(1, 100, ErrorMessage = "Minst 1, max 100")]
        [Display(Name ="Längd(meter)")]
        public int Length { get; set; }

        [Range(1, 100, ErrorMessage = "Minst 1, max 100")]
        [Display(Name = "Bredd(meter)")]
        public int Width { get; set; }

        [Required(ErrorMessage = "Du måste fylla i fältet.")]
        [StringLength(18, ErrorMessage = "Max 18 tecken.")]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Du måste fylla i fältet.")]
        [StringLength(18, ErrorMessage = "Max 18 tecken.")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Du måste fylla i fältet.")]
        [StringLength(20, ErrorMessage = "Max 20 tecken.")]
        [Display(Name = "Telefonummer")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Du måste fylla i fältet.")]
        [StringLength(35, ErrorMessage = "Du måste fylla i en mailadress.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Du måste fylla i fältet.")]
        [StringLength(35, ErrorMessage = "Max 35 tecken.")]
        [Display(Name = "Gata")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Du måste fylla i fältet.")]
        [StringLength(10, ErrorMessage = "Max 10 tecken.")]
        [Display(Name = "Postnummer")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Du måste fylla i fältet.")]
        [StringLength(25, ErrorMessage = "Max 25 tecken.")]
        [Display(Name = "Ort")]
        public string City { get; set; }

        [Display(Name = "Kontakt via")]
        public string ContactOption { get; set; }

        //Constructor
        public OrderModel()
        {
            PriceKvm = 149;
            Kvm = 0;
            TotalPrice = 0;
        }

        //Count properties from form values
        public void Count()
        {
            Kvm = Length * Width;
            TotalPrice = Kvm * PriceKvm;
        }
    }
}
