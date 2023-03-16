namespace PackageDelivery.Repository.Contracts.DbModels.Parameters
{
    public class PersonDbModel
    {
		public  long id { get; set; }

        public string firstName { get; set; }


        public string otherNames { get; set; }


        public string firstLastname { get; set; }

        public string secondLastname { get; set; }

        public string IdentificationNumber { get; set; }

        public string email { get; set; }

        public  int IdentificationType { get; set; }


    }
}
