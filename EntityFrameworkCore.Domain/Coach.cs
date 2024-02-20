namespace EntityFrameworkCore.Domain
{
    public class Coach : BaseDomainModel
    {
        public string Name
        {
            get;
            set;
        }

        public virtual Team? Team
        {
            get;
            set;
        }
    }
}
