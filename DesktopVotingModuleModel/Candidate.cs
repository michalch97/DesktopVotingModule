namespace DesktopVotingModuleModel
{
    public class Candidate
    {
        private string name;
        private int id;

        public string Name
        {
            get { return name; }
        }

        public int Id
        {
            get { return id; }
        }

        public Candidate(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}