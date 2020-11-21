using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RepositoryPatern_Repository
{

    public enum GenreType
    {
        Horror = 1,
        RomCom,
        SciFi,
        Documentary,
        Bromance,
        Drama,
        Action
    }

    // Plain old C# object -- POCO

    public class StreamingContent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MaturityRating { get; set; }
        public double StarRating { get; set; }
        public bool IsFamilyFriendly { get; set; }
        public GenreType TypeOfGenre { get; set; }

        public StreamingContent() { }

        public StreamingContent(string title, string description, string maturityrating, double starrating, bool isfamilyfriendly, GenreType genre)
        {
            Title = title;
            Description = description;
            MaturityRating = maturityrating;
            StarRating = starrating;
            IsFamilyFriendly = isfamilyfriendly;
            TypeOfGenre = genre;
        }
    }
}
