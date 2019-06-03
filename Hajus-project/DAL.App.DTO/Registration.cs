namespace DAL.App.DTO
{
    public class Registration
    {
        
        public int Id { get; set; }
        
        
        public string Title { get; set; }

        public string Comment { get; set; }
       
        public int DogId { get; set; }
        public Dog Dog { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int? CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public int? ShowId { get; set; }
        public Show Show { get; set; }

        public int? SchoolingId { get; set; }

        public Schooling Schooling { get; set; }
    }
}
