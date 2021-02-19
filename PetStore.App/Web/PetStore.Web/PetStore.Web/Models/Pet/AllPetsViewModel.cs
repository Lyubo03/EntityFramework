namespace PetStore.Web.Models.Pet
{
    using System.Collections.Generic;
    using Services.Models.Pets;
    using System;
    public class AllPetsViewModel
    {
        public IEnumerable<PetListingServiceModel> Pets { get; set; }
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public int PreviousPage => this.CurrentPage - 1;
        public int NextPage => this.CurrentPage + 1;
        public bool PreviousBtnDisabled => this.CurrentPage == 1;
        public bool NextDisabled
        {
            get
            {
                var maxPage = Math.Ceiling((double)Total / 25);
                return maxPage == this.CurrentPage;
            }
        }

    }
}